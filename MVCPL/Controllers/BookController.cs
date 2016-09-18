﻿using MVCPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Interface;
using MVCPL.Infrastructure.Mappers;
using MVCPL.Infrastructure;
using BLL;

namespace MVCPL.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;

        public BookController(IBookService bookService, ICommentService commentService)
        {
            _bookService = bookService;
            _commentService = commentService;
        }

        public ActionResult About(int id)
        {
            id = 17;
            BookViewModel book = _bookService.GetBookById(id)?.ToBookViewModel();
            IEnumerable<CommentViewModel> bookComments = _commentService.GetCommentsByBookId(id)?.Select(c => c.ToCommentViewModel());
            if (ReferenceEquals(book, null))
                return HttpNotFound();

            if (ReferenceEquals(bookComments, null))
                bookComments = new CommentViewModel[0];

            var bookInfo = new BookInfoViewModel { Book = book, Comments = bookComments };
            return View(bookInfo);
        }

        public ActionResult Add()
        {
            var book = new BookViewModel();
            book.Authors.AddRange(new List<Author> { new Author { Id = 26, Name = "Емец" }, new Author { Id = 2, Name = "Старовойтов" } });
            book.Genres.AddRange(new List<Genre> { new Genre { Id = 1, Name = "fantasy" }, new Genre { Id = 2, Name = "drama" } });
            TempData["genres"] = book.Genres;
            TempData["authors"] = book.Authors;
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(ExceptionType = typeof(InvalidOperationException))]
        public ActionResult Add(BookViewModel book)
        {
            TryValidateModel(book);
            bool isAdded = false;
            if (ReferenceEquals(book.ImageFile, null))
                ModelState.AddModelError("", "You should load image.");

            if (ModelState.IsValid)
            {
                byte[] image = new byte[book.ImageFile.ContentLength];
                book.ImageFile.InputStream.Read(image, 0, book.ImageFile.ContentLength);
                book.Image = image;
                isAdded = _bookService.AddBook(book.ToDtoBook(), book.NewAuthors, book.NewGenres);

                if (isAdded)
                {
                    ViewBag.Title = "Success";
                    return View(book);
                }
                ModelState.AddModelError("", "This book exists.");
            }
            book.Genres = (List<Genre>)TempData.Peek("genres");
            book.Authors = (List<Author>)TempData.Peek("authors");
            return View(book);
        }

        public FileContentResult Cover(int id)
        {
            throw new NotImplementedException();
        }

        public FileContentResult Download(int id)
        {
            throw new NotImplementedException();
        }
    }
}
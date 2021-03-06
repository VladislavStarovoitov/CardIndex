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
using System.Web.Configuration;

namespace MVCPL.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;

        public BookController(IBookService bookService, ICommentService commentService, IAuthorService authorService, IGenreService genreService)
        {
            _bookService = bookService;
            _commentService = commentService;
            _authorService = authorService;
            _genreService = genreService;
        }

        public ActionResult About(int id)
        {
            BookViewModel book = _bookService.GetBookById(id)?.ToBookViewModel();
            IEnumerable<CommentViewModel> bookComments = _commentService.GetCommentsByBookId(id)?.Select(c => c.ToCommentViewModel()) ?? Enumerable.Empty<CommentViewModel>();
            if (ReferenceEquals(book, null))
                return HttpNotFound();

            if (ReferenceEquals(bookComments, null))
                bookComments = new CommentViewModel[0];

            var bookInfo = new BookInfoViewModel { Book = book, Comments = bookComments };
            return View(bookInfo);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            var book = new BookViewModel();
            book.Genres = _genreService.GetAllGenres()?.Select(g => g.ToGenreViewModel()).ToList() ?? new List<Genre>();
            book.Authors = _authorService.GetAllAuthors()?.Select(a => a.ToAuthorViewModel()).ToList() ?? new List<Author>();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(BookViewModel book)
        {
            bool isAdded = false;
            if (ReferenceEquals(book.CoverFile, null))
                ModelState.AddModelError("", "You should load image.");

            if (ModelState.IsValid)
            {
                isAdded = _bookService.AddBook(book.ToDtoBook(), book.NewAuthors, book.NewGenres);

                if (isAdded)
                {
                    return RedirectToRoute("home");
                }
                ModelState.AddModelError("", "This book exists.");
            }
            book.Genres = _genreService.GetAllGenres()?.Select(g => g.ToGenreViewModel()).ToList() ?? new List<Genre>();
            book.Authors = _authorService.GetAllAuthors()?.Select(a => a.ToAuthorViewModel()).ToList() ?? new List<Author>();
            return View(book);
        }

        public ActionResult Search(string bookName, int page = 1)
        {
            ViewBag.IsSearch = true;
            ViewBag.BookName = bookName;
            int rows = int.Parse(WebConfigurationManager.AppSettings["bookRows"]);
            int booksPerRow = int.Parse(WebConfigurationManager.AppSettings["booksPerRow"]);
            PageInfo info = new PageInfo() { PageNumber = page, TotalItems = _bookService.BookCount(), RowsPerPage = rows, ItemsPerRow = booksPerRow };
            IEnumerable<BookViewModel> books = _bookService.GetBooksByName((page - 1) * info.RowsPerPage, info.RowsPerPage, bookName)
                                               .Select(b => b.ToBookViewModel());
            BookPaginationViewModel bpvm = new BookPaginationViewModel() { Books = books, PageInfo = info };
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Books", bpvm);
            }
            return View(bpvm);
        }

        public FileContentResult Download(int id)
        {
            var content =_bookService.GetBookContent(id);
            if (ReferenceEquals(content.Content, null))
                return null;
            return File(content.Content, content.ContentMimeType);
        }
    }
}
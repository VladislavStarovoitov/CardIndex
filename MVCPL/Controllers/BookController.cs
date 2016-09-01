using MVCPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using MVCPL.Infrastructure.Mappers;
using MVCPL.Infrastructure;

namespace MVCPL.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
             
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBook()
        {
            var book = new BookViewModel();
            book.Authors.AddRange(new List<Author> { new Author { Id = 1, Name = "Емец" }, new Author { Id = 2, Name = "Старовойтов" } });
            book.Genres.AddRange(new List<Genre> { new Genre { Id = 1, Name = "fantasy" }, new Genre { Id = 2, Name = "drama" } });
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //CaseExeptionFilter
        public ActionResult AddBook(BookViewModel book, string newAuthors, string newGenres)
        {
            bool isAdded = false;
            if (ReferenceEquals(book.ImageFile, null))
                ModelState.AddModelError("ImageFile", "You should load image");
            if (ModelState.IsValid)
            {
                byte[] image = new byte[book.ImageFile.ContentLength];
                book.ImageFile.InputStream.Read(image, 0, book.ImageFile.ContentLength);
                book.Image = image;
                isAdded = _bookService.AddBook(book.ToDtoBook(), newAuthors, newGenres);
            }
            if (isAdded)
            {
                ViewBag.Title = "Success";
                return View(book);
            }
            ModelState.AddModelError("", "This book exists");
            return View(book);
        }

        protected override void Dispose(bool disposing)
        {
            _bookService.Dispose();
            base.Dispose(disposing);
        }
    }
}
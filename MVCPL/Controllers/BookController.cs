using MVCPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using MVCPL.Infrastructure.Mappers;
using MVCPL.Infrastructure;
using BLL;

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
            book.Authors.AddRange(new List<Author> { new Author { Id = 26, Name = "Емец" }, new Author { Id = 2, Name = "Старовойтов" } });
            book.Genres.AddRange(new List<Genre> { new Genre { Id = 1, Name = "fantasy" }, new Genre { Id = 2, Name = "drama" } });
            TempData["genres"] = book.Genres;
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //добавить свою страницу с ошибкой
        [HandleError(ExceptionType = typeof(InvalidOperationException))]
        public ActionResult AddBook(BookViewModel book)
        {
            bool isAdded = false;
            if (ReferenceEquals(book.ImageFile, null))
                ModelState.AddModelError("", "You should load image");
 //вынести в ValidObj //temp проверка новых жанров на повторение с существующими
            var genres = book.NewGenres.ToTagArray();
            var authors = book.NewAuthors.ToTagArray();
            var existGenres = (List<Genre>)TempData.Peek("genres");
            genres = genres.Where(g => !existGenres.Select(eG => eG.Name).Contains(g)).Distinct().ToArray();
            //
            //temp2 Проверка на корректность обновляемых данных
            IEnumerable<int> existGenreIds = existGenres.Select(eG => eG.Id);
            foreach (var item in book.GenreIds)
            {
                if (!existGenreIds.Contains(item))
                {
                    ModelState.AddModelError("", "Choose correct genres");
                    break;
                }
            }
            //
            if (ModelState.IsValid)
            {
                byte[] image = new byte[book.ImageFile.ContentLength];
                book.ImageFile.InputStream.Read(image, 0, book.ImageFile.ContentLength);
                book.Image = image;
                isAdded = _bookService.AddBook(book.ToDtoBook(), authors, genres);
            }
            else
            {
                book.Genres = existGenres;
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
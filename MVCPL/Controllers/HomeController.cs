using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mime;
using System.IO;
using MVCPL.Models;
using MVCPL.Infrastructure.Mappers;
using BLL.Interface.Services;

namespace MVCPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        BookViewModel[] _books = new BookViewModel[2];

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index(int page = 1)
        {
            PageInfo info = new PageInfo() { PageNumber = page, TotalItems = _bookService.BookCount() };
            IEnumerable<BookViewModel> books = _bookService.GetBookRange((page - 1) * info.BooksPerPage, info.BooksPerPage)
                                               .Select(b => b.ToBookViewModel());
            IndexViewModel ivm = new IndexViewModel() { Books = books, PageInfo = info };
            return View(ivm);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
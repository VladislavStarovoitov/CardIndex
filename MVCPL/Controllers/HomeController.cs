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
using System.Web.Configuration;

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
            int rows = int.Parse(WebConfigurationManager.AppSettings["bookRows"]);
            PageInfo info = new PageInfo() { PageNumber = page, TotalItems = _bookService.BookCount(), RowsPerPage = rows };
            IEnumerable<BookViewModel> books = _bookService.GetBookRange((page - 1) * info.RowsPerPage, info.RowsPerPage)
                                               .Select(b => b.ToBookViewModel());
            BookPaginationViewModel ivm = new BookPaginationViewModel() { Books = books, PageInfo = info };
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
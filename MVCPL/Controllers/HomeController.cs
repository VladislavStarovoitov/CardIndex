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

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index(int page = 1)
        {
            ViewBag.IsSearch = false;
            int rows = int.Parse(WebConfigurationManager.AppSettings["bookRows"]);
            int booksPerRow = int.Parse(WebConfigurationManager.AppSettings["booksPerRow"]);
            PageInfo info = new PageInfo() { PageNumber = page, TotalItems = _bookService.BookCount(), RowsPerPage = rows, ItemsPerRow = booksPerRow };
            IEnumerable<BookViewModel> books = _bookService.GetBookRange((page - 1) * info.RowsPerPage, info.RowsPerPage)
                                               .Select(b => b.ToBookViewModel());
            BookPaginationViewModel bpvm = new BookPaginationViewModel() { Books = books, PageInfo = info };
            if (Request.IsAjaxRequest())
            {
                return PartialView("Books", bpvm);
            }
            return View(bpvm);
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
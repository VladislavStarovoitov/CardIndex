using MVCPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Mappers;

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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book book, HttpPostedFileBase file)
        {
            byte[] image = new byte[file.ContentLength];
            file.InputStream.Read(image, 0, file.ContentLength);
            book.Image = image;
           
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _bookService.Dispose();
            base.Dispose(disposing);
        }
    }
}
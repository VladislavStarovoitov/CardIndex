using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mime;
using System.IO;
using MVCPL.Models;

namespace MVCPL.Controllers
{
    public class HomeController : Controller
    {
        Book[] _books = new Book[6];

        public HomeController()
        {
            byte[] image;
            using (var file = new FileStream(@"E:\bro.png", FileMode.Open))
            {
                image = new byte[file.Length];
                file.Read(image, 0, image.Length);
            }
            var book = new Book() { Id = 1, Description = "Jast example, my Lord", Name = "G.O.D", Image = image };
            for (int i = 0; i < 6; i++)
            {
                _books[i] = book;
            }
        }

        public ActionResult Index(int page = 1)
        {            
            PageInfo info = new PageInfo() { PageNumber = page, TotalItems = _books.Count() };
            IEnumerable<Book> booksPerPage = _books.Skip((page - 1) * info.PageSize).Take(info.PageSize);
            IndexViewModel ivm = new IndexViewModel() { Books = booksPerPage, PageInfo = info };
            return View(ivm);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            return RedirectToAction("Index");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPL.Models;
using BLL.Interface.Services;
using MVCPL.Infrastructure.Mappers;

namespace MVCPL.Controllers
{
    public class CommentController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public CommentController(IUserService userService, ICommentService commentService)
        {
            _userService = userService;
            _commentService = commentService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _userService.GetUserByEmail(User.Identity.Name);
                comment.AuthorId = currentUser.Id;
                comment.AuthorName = currentUser.Email;
                comment.CreationDate = DateTime.Now;
                _commentService.CreateComment(comment.ToDtoComment());
                if (Request.IsAjaxRequest())
                {
                    return PartialView("~/Views/Book/Comments.cshtml", new List<CommentViewModel> { comment });
                }
                //return RedirectToAction("About", "Book", new { comment.BookId });
            }

            return RedirectToAction("About", "Book", new { comment.BookId });
        }
    }
}
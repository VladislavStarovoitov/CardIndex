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
    [Authorize]
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
                comment.CreationDate = DateTime.Now;
                _commentService.CreateComment(comment.ToDtoComment());
                var comments = _commentService.GetCommentsByBookId(comment.BookId)?.Select(c => c.ToCommentViewModel());
                if (Request.IsAjaxRequest())
                {
                    return PartialView("~/Views/Book/Comments.cshtml", comments);
                }
                return RedirectToAction("About", "Book", new { comment.BookId });
            }

            return RedirectToAction("About", "Book", new { comment.BookId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, int bookId)
        {
            _commentService.Delete(id);
             var comments = _commentService.GetCommentsByBookId(bookId)?.Select(c => c.ToCommentViewModel());
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Book/Comments.cshtml", comments);
            }
            return RedirectToAction("About", "Book", new { bookId });
        }
    }
}
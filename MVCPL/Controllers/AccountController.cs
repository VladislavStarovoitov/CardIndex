using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPL.Models;
using BLL.Interface.Services;
using MVCPL.Infrastructure.Providers;
using System.Web.Security;

namespace MVCPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel signInModel ,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(signInModel.Email, signInModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(signInModel.Email, signInModel.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect email or password.");
                }
            }
            return View(signInModel);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpViewModel signUpModel)
        {
            var anyUser = _userService.GetUserByEmail(signUpModel.Email);
            
            if (!ReferenceEquals(anyUser, null))
            {
                ModelState.AddModelError("", "That username is taken. Try another.");
                return View(signUpModel);
            }


            if (ModelState.IsValid)
            {
                var membershipUser = ((CustomMembershipProvider)Membership.Provider)
                    .CreateUser(signUpModel.Email, signUpModel.Password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(signUpModel.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(signUpModel);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("SignIn", "Account");
        }
    }
}
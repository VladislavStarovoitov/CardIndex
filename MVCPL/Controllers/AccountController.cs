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
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginModel ,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginModel.Email, loginModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginModel.Email, loginModel.RememberMe);
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
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(loginModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerModel)
        {
            var anyUser = _userService.GetUserByEmail(registerModel.Email);
            
            if (!ReferenceEquals(anyUser, null))
            {
                ModelState.AddModelError("", "That username is taken. Try another.");
                return View(registerModel);
            }


            if (ModelState.IsValid)
            {
                var membershipUser = ((CustomMembershipProvider)Membership.Provider)
                    .CreateUser(registerModel.Email, registerModel.Password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(registerModel.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(registerModel);
        }
    }
}
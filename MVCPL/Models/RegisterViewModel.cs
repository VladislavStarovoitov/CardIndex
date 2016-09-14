using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Enter your e-mail")]
        [Required(ErrorMessage = "You can't leave this empty.")]
        [MaxLength(450, ErrorMessage = "Email is very big. Max length 450 chsracters.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Enter your correct email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You can't leave this empty.")]
        [StringLength(20, ErrorMessage = "Short passwords are easy to guess. Try one with at least {0} characters.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You can't leave this empty.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password")]
        [Compare("Password", ErrorMessage = "These passwords don't match. Try again?")]
        public string ConfirmPassword { get; set; }

    }
}
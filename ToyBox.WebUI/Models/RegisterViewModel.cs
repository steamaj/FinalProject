using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ToyBox.WebUI.Models
{
    public class RegisterViewModel
    {
        [HiddenInput (DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter a Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Enter a valid Email Address")]
        [Required(ErrorMessage = "Enter a Email Address")]

        public string Email { get; set; }



        [Required(ErrorMessage = "Password is required")]
        [DataType("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType("Password")]
        [System.Web.Mvc.Compare("Password", ErrorMessage ="Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
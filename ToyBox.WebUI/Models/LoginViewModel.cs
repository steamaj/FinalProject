using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToyBox.WebUI.Models
{
    public class LoginViewModel
    {
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Enter a valid Email Address")]
        [Required(ErrorMessage = "Enter a Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a Password")]
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToyBox.WebUI.Models;
using System.Web.Mvc;
using System.Web.Security;
using ToyBox.WebUI.Infrastructure.Abstract;
using ToyBox.Domain.Abstract;
using ToyBox.Domain.Entities;
using ToyBox.Domain.Concrete;
using System.Web.Helpers;
using System.Security.Principal;
using Microsoft.AspNet.Identity;





namespace ToyBox.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private IUserRepository repository;

        public AccountController(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }











        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ViewResult Register()
        {
            return View();
        }




        [HttpPost]
        public ActionResult SaveRegisterDetails(RegisterViewModel registerDetails)
        {
            //We check if the model state is valid or not. We have used DataAnnotation attributes.
            //If any form value fails the DataAnnotation validation the model state becomes invalid.
            if (ModelState.IsValid)
            {
                

                //create database context using Entity framework 
                using (var databaseContext = new EFDbContext())
                {
                    var isEmailAlreadyExists = repository.Users.Any(a => a.Email == registerDetails.Email);
                    if (isEmailAlreadyExists)
                    {
                        ModelState.AddModelError("Email", "User with this email already exists");
                        return View("Register", registerDetails);
                    }


                    //If the model state is valid i.e. the form values passed the validation then we are storing the User's details in DB.
                    User reglog = new User();

                    //Save all details in RegitserUser object
                    var hashPassword = Crypto.HashPassword(registerDetails.Password);

                    reglog.FirstName = registerDetails.FirstName;
                    reglog.LastName = registerDetails.LastName;
                    reglog.Email = registerDetails.Email;
                    reglog.Password = hashPassword;


                    //Calling the SaveDetails method which saves the details.
                    databaseContext.Users.Add(reglog);
                    databaseContext.SaveChanges();
                }

                FormsAuthentication.SetAuthCookie(registerDetails.Email, false);
                return RedirectToAction("List", "Product");
                //ViewBag.Message = "User Details Saved";
                //return View("Register");
            }
            else
            {

                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View("Register", registerDetails);
            }
        }







        //-----------------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            using (var context = new EFDbContext())
            {
                var getUser = (from s in context.Users where s.Email == model.Email select s).FirstOrDefault();
                var getPass = (from s in context.Users where s.Password == model.Password select s).FirstOrDefault();
                if (getUser != null && getPass != null)
                {
                    var hashCode = getUser.Password;

                    if (Crypto.VerifyHashedPassword(hashCode, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        return RedirectToAction("List", "Product");
                    }
                    else
                    {
                        //ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                        return View();
                    }

                    
                }
                ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                return View();
            }
        }

        public ActionResult PostedProducts()
        {
            string email = User.Identity.Name;
            User user = repository.Users.FirstOrDefault(u => u.Email.Equals(email));


            User model = new User();
            model.Id = user.Id;

            return View(model);
        }



        public new ViewResult Profile ( )
        {
            string email = User.Identity.Name;
            User user = repository.Users.FirstOrDefault(u => u.Email.Equals(email));


            User model = new User();
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            
            return View(model);

        }
        [HttpPost]
        public new ActionResult Profile(User userProfile)
        {
            if (ModelState.IsValid)
            {
                string email = User.Identity.Name;
                User user = repository.Users.FirstOrDefault(u => u.Email.Equals(email));

                user.FirstName = userProfile.FirstName;
                user.LastName = userProfile.LastName;

                repository.SaveChanges(userProfile);

                TempData["message"] = string.Format
                    ("{0} has been updated", user.Email);

                return RedirectToAction("Profile", "Account");
            }

            return View(userProfile);
        }




        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login", "Account");
        }

        //function to check if User is valid or not

    }
}
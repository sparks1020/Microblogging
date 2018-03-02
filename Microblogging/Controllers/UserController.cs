using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AuthenticationBase.Models.Authentication;
using Microblogging.Database_files;

namespace AuthenticationBase.Controllers
{
    public class UserController : Controller
    {
        // GET /User
        // This is the profile page
        [AuthenticationRequired]
        public ActionResult Index()
        {
            var identity = ControllerContext.HttpContext.User.Identity;

            return View(identity);
        }

        // GET /User/Login
        // This is the login form
        public ActionResult Login()
        {
            return View(new AuthenticationForm());
        }

        // POST /User/Login
        // This handles the login request
        [HttpPost]
        public ActionResult Login(AuthenticationForm form)
        {
            if (string.IsNullOrWhiteSpace(form.Username) || string.IsNullOrWhiteSpace(form.Password))
            {
                form.ErrorMessage = "Username and password are both required!";
                return View(form);
            }

            using (var db = new PostsContext())
            {
                var user = db.Accounts.FirstOrDefault(a => a.Username == form.Username.ToLower());
                if (user == null || !Crypto.VerifyHashedPassword(user.HashedPassword, form.Password))
                {
                    form.ErrorMessage = "Incorrect username or password!";
                    return View(form);
                }

                // Store the (now) logged-in user in session
                Session["user"] = user;
            }

            return RedirectToAction("Index", "Post");
        }

        // GET /User/Logout
        // This handles the logout action
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET /User/Register
        // This is the registration form
        public ActionResult Register()
        {
            return View(new RegistrationForm());
        }

        // POST /User/Register
        // This handles registration
        [HttpPost]
        public ActionResult Register(RegistrationForm form)
        {
            if (string.IsNullOrWhiteSpace(form.Username) || string.IsNullOrWhiteSpace(form.Password) ||
                string.IsNullOrWhiteSpace(form.PasswordConfirm) || string.IsNullOrWhiteSpace(form.EmailAddress))
            {
                form.ErrorMessage = "All fields are required!";
                return View(form);
            }

            if (form.Password != form.PasswordConfirm)
            {
                form.ErrorMessage = "Password and confirmation do not match!";
                return View(form);
            }

            if (form.Password.Length < 8)
            {
                form.ErrorMessage = "Passwords must be at least 8 characters long";
                return View(form);
            }

            using (var db = new PostsContext())
            {
                // For a real setup, uncomment the email check, to require unique email addresses and usernames
                var account = db.Accounts.FirstOrDefault(a => a.Username == form.Username.ToLower() /* || a.EmailAddress == form.EmailAddress.ToLower() */);
                if (account != null)
                {
                    form.ErrorMessage = "There is already an account with these details";
                    return View(form);
                }

                // Create the new account
                db.Accounts.Add(new Account
                {
                    Username = form.Username.ToLower(),
                    HashedPassword = Crypto.HashPassword(form.Password),
                    EmailAddress = form.EmailAddress
                });
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

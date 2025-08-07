using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using InternetProgrammingProject.Models;

namespace WebApplication5.Controllers
{
    public class UserController : Controller
    {
        private readonly DbSignupContext _context;

        public UserController(DbSignupContext context)
        {
            _context = context;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(User user)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Home/Signup.cshtml", user);

            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "An account with this email already exists.");
                return View("~/Views/Home/Signup.cshtml", user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return View("~/Views/Home/SignupSuccess.cshtml");
        }

        public IActionResult Login() => View("~/Views/Home/Login.cshtml");

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ViewBag.Error = "Invalid login credentials";
                return View("~/Views/Home/Login.cshtml");
            }
            ViewBag.FirstName = user.FirstName;
            ViewBag.LastName = user.LastName;
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserFirstName", user.FirstName);
            HttpContext.Session.SetString("UserLastName", user.LastName);
            return View("~/Views/Home/LoginSuccessful.cshtml");
        }

    }
}

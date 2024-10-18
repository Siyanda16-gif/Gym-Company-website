using MCPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCPA.Controllers
{
    public class AccountController : Controller
    {
        private UserRepository _userRepository = new UserRepository();

        public ActionResult SignUp()
        {
            ViewBag.HideHeader = true;
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            ViewBag.HideHeader = true;
            if (ModelState.IsValid)
            {
                // Check if the username already exists
                var existingUser = _userRepository.GetUserByUsername(user.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Username already exists.");
                    return View(user);
                }

                // Add the user to the repository
                _userRepository.AddUser(user);

                // Redirect to login page
                return RedirectToAction("Login");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            ViewBag.HideHeader = true;
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
    {
            ViewBag.HideHeader = true;
            if (ModelState.IsValid)
        {
            // Check if the user exists and the password is correct
            var existingUser = _userRepository.GetUserByUsername(user.Username);
            if (existingUser == null || existingUser.Password != user.Password)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(user);
            }

            // Store the user's information in a session or cookie
            // Redirect to the dashboard or desired page
            return RedirectToAction("Sgora");
        }

        return View(user);
    }

    public ActionResult Dashboard()
    {
        return View();
    }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Sgora()
        {
            return View();
        }

        public ActionResult Staff()
        {
            return View();
        }
    }
}
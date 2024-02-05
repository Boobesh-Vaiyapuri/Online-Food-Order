using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zomoto.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace zomoto.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            int userId = DbHelper.InsertUser(user);

            ViewBag.Message = userId > 0 ? "Registration successful" : "Registration failed";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            bool isValidUser = DbHelper.ValidateUser(username, password);

            if (isValidUser)
            {
                // Successful login, redirect to a dashboard or home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Failed login, show an error message
                ViewBag.Message = "Invalid username or password";
                 return View();
            }
        }
    }
}
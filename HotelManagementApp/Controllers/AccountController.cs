using HotelManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly HotelContext db = new HotelContext();

        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Email == user.Email))
                {
                    ViewBag.Message = "Email already registered!";
                    return View();
                }

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserRole"] = user.Role;
                return RedirectToAction("Index", "Booking");
            }
            ViewBag.Message = "Invalid credentials!";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
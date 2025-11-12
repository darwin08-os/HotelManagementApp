using HotelManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementApp.Controllers
{
 
        // GET: Admin
        public class AdminController : Controller
        {
            private readonly HotelContext db = new HotelContext();

            public ActionResult Users()
            {
                if ((string)Session["UserRole"] != "Admin")
                    return RedirectToAction("Login", "Account");

                return View(db.Users.ToList());
            }

            public ActionResult DeleteUser(int id)
            {
                var user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                return RedirectToAction("Users");
            }
        }
    }

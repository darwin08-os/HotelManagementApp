using HotelManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly HotelContext db = new HotelContext();

        public ActionResult Index()
        {
            var rooms = db.Rooms.Where(r => r.IsAvailable).ToList();
            return View(rooms);
        }

        [HttpPost]
        public ActionResult Book(int roomId, DateTime checkIn, DateTime checkOut)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            var room = db.Rooms.Find(roomId);
            if (room == null || !room.IsAvailable)
                return HttpNotFound();

            var booking = new Booking
            {
                RoomId = roomId,
                UserId = (int)Session["UserId"],
                CheckInDate = checkIn,
                CheckOutDate = checkOut
            };

            room.IsAvailable = false;
            db.Bookings.Add(booking);
            db.SaveChanges();

            return RedirectToAction("MyBookings");
        }

        public ActionResult MyBookings()
        {
            int uid = (int)Session["UserId"];
            var bookings = db.Bookings.Where(b => b.UserId == uid).ToList();
            return View(bookings);
        }

        public ActionResult Cancel(int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking != null)
            {
                booking.Status = "Cancelled";
                var room = db.Rooms.Find(booking.RoomId);
                room.IsAvailable = true;
                db.SaveChanges();
            }
            return RedirectToAction("MyBookings");
        }
    }
}
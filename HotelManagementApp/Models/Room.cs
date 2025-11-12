using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagementApp.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; } = true;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
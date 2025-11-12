namespace HotelManagementApp.Migrations
{
    using HotelManagementApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelManagementApp.Models.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(HotelManagementApp.Models.HotelContext context)
        {
            context.Users.AddOrUpdate(u => u.Email,
    new User
    {
        Name = "Admin",
        Email = "admin@hotel.com",
        Password = "admin123", // TODO: hash later for security
        Role = "Admin"
    }
);
            context.Rooms.AddOrUpdate(r => r.RoomNumber,
                new Room { RoomNumber = "101", PricePerNight = 120, IsAvailable = true },
                new Room { RoomNumber = "102", PricePerNight = 150, IsAvailable = true }
            );
        }
    }
}

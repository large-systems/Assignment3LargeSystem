using HotelSystem.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HotelSystem
{
    public class HotelContext : DbContext
    {

        public HotelContext() : base("HotelContext")
        {
            //connection string goes here
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelChain> HotelChains { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
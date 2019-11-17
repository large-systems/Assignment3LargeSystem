using HotelSystem.Model;
using System.Data.Entity;

namespace HotelSystem
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class HotelContext : DbContext
    {

        public HotelContext() : base("HotelContext")
        {
            Database.SetInitializer<HotelContext>(null);
            //connection string goes here
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelChain> HotelChains { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
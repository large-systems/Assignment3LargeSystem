using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelSystem.Model;

namespace HotelSystem
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestWhoBookedId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumOfGuests { get; set; }
        public int NumOfRooms { get; set; }
        public DateTime TimeArrival { get; set; }
    }
}
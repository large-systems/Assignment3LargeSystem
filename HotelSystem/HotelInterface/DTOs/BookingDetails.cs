using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.DTOs
{
    public class BookingDetails : BookingIdentifier
    {
        public DateTime _startDateTime;
        public DateTime _endDate;
        public int _numberOfGuests;
        public int _numberOfRooms;
        public DateTime _arrival;
        public List<RoomDetails> _listOfRoomsDetails;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime Arrival { get; set; }

        public List<RoomDetails> ListOfRoomsDetails { get; set; }


        public BookingDetails(int id) : base(id)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelSystem.Model;

namespace HotelSystem
{
    public class Booking 
    {

        private DateTime _startDate;
        private DateTime _endDate;

        private int _numberOfGuests;
        private List<Room> _roomsBooked;

        private DateTime _arrival;


        public DateTime StartDate { get { return _startDate; } set { _startDate = value; } }

        public DateTime EndDate { get { return _endDate; } set { _endDate = value; } }

        public int NumberOfGuests { get { return _numberOfGuests; } set { _numberOfGuests = value; } }

        public List<Room> RoomBooked { get { return _roomsBooked; } set {  _roomsBooked = value; } }


        public DateTime Arrival { get { return _arrival; } set { _arrival = value; } }



    }
}
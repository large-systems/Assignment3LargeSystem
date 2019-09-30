using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Model
{
    public class BookingIdentifier
    {
        private int _id;

        public int ID { get { return _id; } set { _id = value; } }

        public BookingIdentifier(int id)
        {
            _id = id;
        }
    }
}
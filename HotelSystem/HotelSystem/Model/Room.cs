using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Model
{
    public class Room : Identifier
    {
        private string _rooomType;

        private int _roomNumber;

        private double _price;


        public string RoomType { get { return _rooomType; } set { _rooomType = value; } }

        public int RoomNumber  { get { return _roomNumber; } set { _roomNumber = value; } }

        public double Price { get { return _price ; } set { _price = value; } }

    }
}
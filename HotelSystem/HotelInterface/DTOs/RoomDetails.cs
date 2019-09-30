using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelSystem.DTOs
{
    [DataContract]
    public class RoomDetails : RoomIdentifier
    {

        public int _id;
        public int _roomNumber;
        public string _roomType;
        public double _price;
        public int _capacity;


     

        public int RoomNumber { get; set; }

        public string RoomType { get; set; }

        public double Price { get; set; }

        public int Capacity { get; set; }

        public RoomDetails(int id) : base(id)
        {
            
        }
    }
}
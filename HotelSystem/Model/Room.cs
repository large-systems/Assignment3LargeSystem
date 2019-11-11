using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Model
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomType { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
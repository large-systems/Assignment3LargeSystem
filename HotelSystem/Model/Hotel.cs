using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem
{
    public class Hotel
    {
        public int Id { get; set; }
        public int HotelChainsId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double DistanceToCenter { get; set; }
        public int StarRating { get; set; }
    }
}
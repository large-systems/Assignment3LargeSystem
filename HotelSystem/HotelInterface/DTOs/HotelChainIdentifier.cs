using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.DTOs
{
    public class HotelChainIdentifier
    {
        private int _id;

        public int ID { get { return _id; } set { _id = value; } }

        public HotelChainIdentifier(int id)
        {
            _id = id;
        }
    }
}
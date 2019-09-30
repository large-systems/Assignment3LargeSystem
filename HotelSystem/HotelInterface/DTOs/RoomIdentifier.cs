using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelSystem.DTOs
{
    [DataContract]
    public class RoomIdentifier
    {

        private int _id;

        public int ID { get { return _id; } set { _id = value; } }

        public RoomIdentifier(int id)
        {
            _id = id;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelInterface.DTOs
{
    [DataContract]
    public class HotelIdentifier
    {
        private int _id;

        public int ID { get { return _id; } set { _id = value; } }

        public HotelIdentifier(int id)
        {
            _id = id;
        }
    }
}

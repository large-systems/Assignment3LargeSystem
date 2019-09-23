using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem
{
    public class Hotel : Identifier
    {

        private string _name;

        private string _streetName;

        private string _city;

        private int _zipCode;

        private float _distanceToCity;

        private int _starCity;


        public string Name { get { return _name; } set { _name = value; } }

        public string StreetName { get { return _streetName; } set { _streetName = value; } }

        public string City { get { return _city; } set { _city = value; } }

        public int ZipCode { get { return _zipCode; } set { _zipCode = value; } }

        public float DistanceToCity { get { return _distanceToCity; } set { _distanceToCity = value; } }


        public int StarCity { get { return _starCity; } set { _starCity = value; } }




    }
}
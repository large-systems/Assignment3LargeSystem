using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem
{
    public class Customer
    {
        private int _passportNumber;

        private string _name;


        public int PassportNumber { get { return _passportNumber; } set { _passportNumber = value; } }

        public string Name { get { return _name; } set { _name = value; } }

    }
}
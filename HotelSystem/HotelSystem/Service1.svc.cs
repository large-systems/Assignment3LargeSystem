using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HotelSystem.Model;

namespace HotelSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void LogOn(int id, string password)
        {
            throw new NotImplementedException();
        }

        public List<Booking> SelectBooking()
        {
            throw new NotImplementedException();
        }

        public void FindBooking(DateTime startDate, DateTime endDate, string roomType, int passportNummber, Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Booking SelectSpecificBooking(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> FindHotelRoom(DateTime date, string city)
        {
            throw new NotImplementedException();
        }

        public List<Room> FindRooms(DateTime date, Hotel hotel, string roomType)
        {
            throw new NotImplementedException();
        }

        public void SelectRoom()
        {
            throw new NotImplementedException();
        }
    }
}

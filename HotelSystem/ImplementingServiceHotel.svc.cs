using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelInterface.DTOs;
using HotelInterface.Interface;
using HotelSystem.DTOs;

namespace HotelSystem
{
    public class ImplementingServiceHotel : IServiceHotel
    {
        public void AddNewHotel(string name, string city, string adress, HotelChainIdentifier hotelChainIdentifier)
        {
            throw new NotImplementedException();
        }

        public void CancelBooking(BookingIdentifier bookingIdentifier)
        {
            throw new NotImplementedException();
        }

        public bool CreateBooking(DateTime startDate, DateTime endDate, int numberGuest, List<RoomIdentifier> listOfRooms, int passportNumber, string guestNumber)
        {
            return true;
        }

        public string EchoTest(string input)
        {
            return "Hotel service echo:" + input;
        }

        public BookingDetails FindBookingByid(BookingIdentifier bookingIdentifier)
        {
            throw new NotImplementedException();
        }

        public List<BookingDetails> FindBookings(int passPortNUmber)
        {
            throw new NotImplementedException();
        }

        public List<RoomDetails> FindRooms(DateTime date, HotelIdentifier hotel, string roomType)
        {
            throw new NotImplementedException();
        }
    }
}
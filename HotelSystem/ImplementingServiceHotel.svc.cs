using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelInterface.DTOs;
using HotelInterface.Interface;
using HotelSystem.Model;

namespace HotelSystem
{
    public class ImplementingServiceHotel : IServiceHotel
    {
        public void AddNewHotel(string name, string city, string address, HotelChainIdentifier hotelChainIdentifier)
        {
            using(var dbContext = new HotelContext())
            {
                var hotel = new Hotel() { Name = name, City = city, Address = address, HotelChainsId = hotelChainIdentifier.ID };
                var dbInsert = dbContext.Hotels.Add(hotel);
            }

        }

        public void CancelBooking(BookingIdentifier bookingIdentifier)
        {
            using (var dbContext = new HotelContext())
            {
                var booking = dbContext.Bookings.Where(b => b.Id.Equals(bookingIdentifier)).First();
                var dbDelete = dbContext.Bookings.Remove(booking);
            }
        }

        public bool CreateBooking(DateTime startDate, DateTime endDate, int numberGuest, List<RoomIdentifier> listOfRooms, int passportNumber, string guestNumber)
        {
            using(var dbContext = new HotelContext())
            {
                var rooms = dbContext.Rooms.Where(r => listOfRooms.Find(s => r.Id.Equals(s.ID)) != null).ToList();
                var guest = dbContext.Guests.Where(p => p.PassportNumber.Equals(passportNumber)).First();
                if(guest == null)
                {
                    guest = new Guest() { PassportNumber = passportNumber };
                }
                var booking = new Booking() { StartDate = startDate, EndDate = endDate, NumOfGuests = numberGuest, RoomRelation = rooms, GuestRelation = guest };
                var dbInsert = dbContext.Bookings.Add(booking);
                if(dbInsert != null)
                {
                    return true;
                }
                return false;
            }
        }

        public string EchoTest(string input)
        {
            return "Hello from backend";
        }

        public BookingDetails FindBookingByid(BookingIdentifier bookingIdentifier)
        {
            using(var dbContext = new HotelContext())
            {
                var booking = dbContext.Bookings.Where(b => b.Id.Equals(bookingIdentifier)).First();
                var dbFind = dbContext.Bookings.Find(booking);
                return dbFind; //BookingDetails class does not correspond to Booking model. This will have to be discussed
            }
        }

        public List<BookingDetails> FindBookings(int passPortNUmber)
        {
            using(var dbContext = new HotelContext())
            {
                var guest = dbContext.Guests.Where(p => p.PassportNumber.Equals(passPortNUmber)).First();
                var bookings = dbContext.Bookings.Where(p => p.GuestRelation.PassportNumber.Equals(passPortNUmber)).ToList();
                return bookings;
            }
        }

        public List<RoomDetails> FindRooms(DateTime date, HotelIdentifier hotel, string roomType)
        {
            throw new NotImplementedException();
        }
    }
}
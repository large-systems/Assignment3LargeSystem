using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using HotelInterface.DTOs;
using HotelInterface.Interface;
using HotelSystem.Exception;
using HotelSystem.Mapper;
using HotelSystem.Model;

namespace HotelSystem
{
    public class ImplementingServiceHotel : IServiceHotel
    {
        private BookingMapper bookingMapper;

        public ImplementingServiceHotel(): base()
        {
            bookingMapper = new BookingMapper();
        }

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
                var booking = dbContext.Bookings.FirstOrDefault(b => bookingIdentifier.ID == b.Id);
                if (booking == null)
                {
                    throw new FaultException<BookingNotFoundException>(new BookingNotFoundException(), "Booking not found");
                }
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
                // TODO room relation is wrong
                /*var booking = new Booking() { StartDate = startDate, EndDate = endDate, NumOfGuests = numberGuest, RoomRelation = rooms, GuestRelation = guest };
                var dbInsert = dbContext.Bookings.Add(booking);
                if(dbInsert != null)
                {
                    return true;
                }*/
                return false;
            }
        }

        public string EchoTest(string input)
        {
            return "Hotel service echo:" + input;
        }

        public BookingDetails FindBookingByid(BookingIdentifier bookingIdentifier)
        {
            using(var dbContext = new HotelContext())
            {
                var booking = dbContext.Bookings.FirstOrDefault(b => b.Id == bookingIdentifier.ID);
                if (booking == null)
                {
                    throw new FaultException<BookingNotFoundException>(new BookingNotFoundException(), "Booking not found");
                }
                return bookingMapper.ToDetails(booking);
            }
        }

        public List<BookingDetails> FindBookings(int passPortNUmber)
        {
            using(var dbContext = new HotelContext())
            {
                var guest = dbContext.Guests.FirstOrDefault(p => p.PassportNumber.Equals(passPortNUmber));
                if (guest == null)
                {
                    return new List<BookingDetails>(0);
                }
                var bookings = dbContext.Bookings.Where(p => p.GuestRelation.PassportNumber.Equals(passPortNUmber)).ToList();
                var newBookings =bookings.Select(bookingMapper.ToDetails).ToList();
                return newBookings;
            }
        }

        public List<RoomDetails> FindRooms(DateTime date, HotelIdentifier hotel, string roomType)
        {
            throw new NotImplementedException();
        }
    }
}
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
    [HotelServiceBehavior]
    public class ImplementingServiceHotel : IServiceHotel
    {
        private BookingMapper bookingMapper;
        private HotelMapper hotelMapper;
        private RoomMapper roomMapper;

        public ImplementingServiceHotel(): base()
        {
            bookingMapper = new BookingMapper();
            hotelMapper = new HotelMapper();
            roomMapper = new RoomMapper();
        }

        public void AddNewHotel(string name, string city, string address, HotelChainIdentifier hotelChainIdentifier)
        {
            using(var dbContext = new HotelContext())
            {
                var hotel = new Hotel() { Name = name, City = city, Address = address, HotelChainsId = hotelChainIdentifier.ID };
                var dbInsert = dbContext.Hotels.Add(hotel);
                dbContext.SaveChanges();
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
                dbContext.SaveChanges();
            }
        }

        public bool CreateBooking(DateTime startDate, DateTime endDate, int numberGuest, List<RoomIdentifier> listOfRooms, int passportNumber, string guestNumber)
        {
            // TODO handle concurrency.
            using(var dbContext = new HotelContext())
            {
                var roomIds = listOfRooms.Select(r => r.ID).ToList();
                var rooms = dbContext.Rooms.Where(r => roomIds.Contains(r.Id)).ToList();
                var guest = dbContext.Guests.FirstOrDefault(p => p.PassportNumber.Equals(passportNumber));
                if(guest == null)
                {
                    guest = new Guest() { PassportNumber = passportNumber };
                }

                var booking = new Booking()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    NumOfGuests = numberGuest,
                    NumOfRooms = rooms.Count(),
                    RoomRelation = rooms.Select(r => new BookingRoom() { RoomId = r.Id }).ToList(),
                    GuestRelation = guest
                };
                dbContext.Bookings.Add(booking);
                return dbContext.SaveChanges() > 0;
            }
        }

        public string EchoTest(string input)
        {
            return "Hello from backend";
        }

        public List<HotelDetails> FindAvailableHotels(DateTime startDate, DateTime endDate, int numRooms, string city)
        {
            using (var dbContext = new HotelContext())
            {
                // https://stackoverflow.com/a/15168236
                // Allegedly EF sucks at querying nested _-to-many relations
                // Therefore do the last filtering in c#
                var hotels = dbContext.Hotels.Where(h => h.City.ToLower() == city.ToLower()).ToList();
                hotels = hotels.Where(
                    h => FilterAvailableRooms(h.RoomRelation, startDate, endDate, "").Count() >= numRooms
                ).ToList();

                var hotelDetails = hotels.Select(hotelMapper.ToDetails).ToList();
                return hotelDetails;
            }
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
                var bookings = dbContext.Bookings
                    .Include("RoomRelation.Room")
                    .Where(p => p.GuestRelation.PassportNumber.Equals(passPortNUmber))
                    .ToList();
                var newBookings =bookings.Select(bookingMapper.ToDetails).ToList();
                return newBookings;
            }
        }

        public List<RoomDetails> FindRooms(HotelIdentifier hotel, DateTime startDate, DateTime endDate, string roomType)
        {
            using (var dbContext = new HotelContext())
            {
                var hotelEntity = dbContext.Hotels.FirstOrDefault(h => h.Id == hotel.ID);
                if (hotelEntity != null)
                {
                    return FilterAvailableRooms(hotelEntity.RoomRelation, startDate, endDate, roomType)
                        .Select(r => roomMapper.ToDetails(r))
                        .ToList();
                }
                return new List<RoomDetails>();
            }
        }

        private IEnumerable<Room> FilterAvailableRooms(ICollection<Room> rooms, DateTime startDate, DateTime endDate, string roomType)
        {
            // Filter Rooms based on whether they DO NOT have bookings in that period
            return rooms.Where(r =>
                (string.IsNullOrEmpty(roomType) || r.RoomType == roomType)
                && r.BookingRelation.Where(
                    b => b.Booking.StartDate >= startDate && b.Booking.EndDate <= endDate
                ).Count() == 0
            );
        }
    }
}
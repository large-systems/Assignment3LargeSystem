using HotelSystem;
using HotelInterface.DTOs;
using NUnit.Framework;
using System.Collections.Generic;

namespace HotelTest
{
    public class Tests
    {
        ImplementingServiceHotel hotelsystem = null;
        [SetUp]
        public void Setup()
        {
            hotelsystem = new HotelSystem.ImplementingServiceHotel();
        }

        [Test]
        public void EchoTest()
        {
            string result = hotelsystem.EchoTest("");
            Assert.AreEqual("Hello from backend", result);
        }

        [Test]
        public void AddHotelTest()
        {
            Assert.DoesNotThrow(() => hotelsystem.AddNewHotel("Test hotel", "Hotelby", "Hotelvej 1", new HotelChainIdentifier(1)));
        }

        [Test]
        public void FindBookingsTest()
        {
            Assert.Greater(0, hotelsystem.FindBookings(12345678).Count);
        }

        [Test]
        public void FindBookingByIdTest()
        {
            Assert.DoesNotThrow(() => hotelsystem.FindBookingByid(new BookingIdentifier(1)));
        }

        [Test]
        public void FindRoomsTest()
        {
            // DateTime is in the format year, month, day, hour, minute, second
            Assert.Greater(0, hotelsystem.FindRooms(new System.DateTime(2019, 3, 1, 7, 0, 0), new HotelIdentifier(1), "Luksusrum").Count);
        }

        [Test]
        public void CreateBookingTest()
        {
            // DateTime is in the format year, month, day, hour, minute, second
            List<RoomIdentifier> listOfRooms = new List<RoomIdentifier>();
            listOfRooms.Add(new RoomIdentifier(1));
            Assert.IsTrue(hotelsystem.CreateBooking(new System.DateTime(2019, 3, 1, 7, 0, 0), new System.DateTime(2019, 3, 3, 7, 0, 0), 8, listOfRooms, 12345678, "asiodjfaosjdf"));
        }
    }
}
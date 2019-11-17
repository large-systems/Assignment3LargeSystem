using HotelInterface.DTOs;
using HotelSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Mapper
{
    public class BookingMapper
    {
        private RoomMapper roomMapper = new RoomMapper();

        public BookingDetails ToDetails(Booking booking)
        {
            return new BookingDetails(booking.Id)
            {
                ID = booking.Id,
                Arrival = booking.TimeArrival,
                EndDate = booking.EndDate,
                NumberOfRooms = booking.NumOfRooms,
                StartDate = booking.StartDate,
                // TODO fix when relation fixed
                ListOfRoomsDetails = new List<RoomDetails>(new RoomDetails[] { roomMapper.ToDetails(booking.RoomRelation) }),
            };
        }
    }
}
using HotelInterface.DTOs;
using HotelSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Mapper
{
    public class RoomMapper
    {
        public RoomDetails ToDetails(Room room)
        {
            return new RoomDetails(room.Id)
            {
                ID = room.Id,
                Capacity = room.Capacity,
                Price = room.Price,
                RoomType = room.RoomType,
                // TODO roomnumber when fixed
            };
        }

        public RoomIdentifier ToIdentifier(Room room)
        {
            return new RoomIdentifier(room.Id);
        }
    }
}
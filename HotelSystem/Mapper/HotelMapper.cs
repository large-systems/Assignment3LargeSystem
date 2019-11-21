using HotelInterface.DTOs;
using HotelSystem.Model;
using System.Collections.Generic;
using System.Linq;

namespace HotelSystem.Mapper
{
    public class HotelMapper
    {
        private RoomMapper roomMapper = new RoomMapper();

        public HotelDetails ToDetails(Hotel hotel)
        {
            return new HotelDetails(hotel.Id)
            {
                Address = hotel.Address,
                City = hotel.City,
                DistanceToCenter = (float)hotel.DistanceToCenter,
                Name = hotel.Name,
                StarRating = hotel.StarRating,
                Rooms = new List<Room>(hotel.RoomRelation).Select(roomMapper.ToIdentifier).ToList(),
            };
        }
    }
}
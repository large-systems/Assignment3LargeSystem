using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelSystem.Model
{
    [Table("rooms")]
    public class Room
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("hotel_id")]
        public int HotelId { get; set; }
        [Column("room_type")]
        public string RoomType { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("capacity")]
        public int Capacity { get; set; }

        [ForeignKey("HotelId")]
        public virtual ICollection<Hotel> HotelRelation { get; set; }
        [InverseProperty("RoomRelation")]
        public virtual ICollection<Booking> BookingRelation { get; set; }
    }
}
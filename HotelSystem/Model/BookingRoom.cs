using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelSystem.Model
{
    [Table("booking_room")]
    public class BookingRoom
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("booking_id")]
        public int BookingId { get; set; }
        [Column("room_id")]
        public int RoomId { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }
}
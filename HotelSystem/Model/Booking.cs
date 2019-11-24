using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HotelSystem.Model;

namespace HotelSystem.Model
{
    [Table("booking")]
    public class Booking
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("guest_who_booked_id")]
        public int GuestWhoBookedId { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("num_of_guests")]
        public int NumOfGuests { get; set; }
        [Column("num_of_rooms")]
        public int NumOfRooms { get; set; }
        [Column("time_arrival")]
        public DateTime TimeArrival { get; set; }


        public virtual List<BookingRoom> RoomRelation { get; set; }
        [ForeignKey("GuestWhoBookedId")]
        public virtual Guest GuestRelation { get; set; }
    }
}
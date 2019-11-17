using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelSystem.Model
{
    [Table("guest")]
    public class Guest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("passport_number")]
        public int PassportNumber { get; set; }


        [InverseProperty("GuestRelation")]
        public virtual ICollection<Booking> BookingRelation { get; set; }
    }
}
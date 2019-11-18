using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSystem.Model
{
    [Table("hotels")]
    public class Hotel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("hotel_chains_id")]
        public int HotelChainsId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("distance_to_center")]
        public double DistanceToCenter { get; set; }
        [Column("star_rating")]
        public int StarRating { get; set; }

        [ForeignKey("HotelChainsId")]
        public virtual HotelChain HotelChainRelation { get; set; }

        [InverseProperty("HotelRelation")]
        public virtual ICollection<Room> RoomRelation { get; set; }
    }
}
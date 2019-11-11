using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Model
{
    public class HotelChain
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Hotel> HotelRelation { get; set; }
    }
}
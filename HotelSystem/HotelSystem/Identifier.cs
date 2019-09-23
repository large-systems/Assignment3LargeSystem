using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem
{
    public class Identifier
    {
        private Guid _id;

        public Identifier()
        {
            _id = Guid.NewGuid();
        }
          
        
    }


}
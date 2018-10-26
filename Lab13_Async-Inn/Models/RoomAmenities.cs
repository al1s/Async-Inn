using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenityId { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public Amenities Amenities { get; set; }
    }
}

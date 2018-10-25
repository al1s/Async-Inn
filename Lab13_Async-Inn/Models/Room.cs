using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int LayoutId { get; set; }
        public ICollection<HotelRoom> Hotels { get; set; }
        public ICollection<RoomAmenities> Amenities { get; set; }
        public Layout Layout { get; set; }
    }
}

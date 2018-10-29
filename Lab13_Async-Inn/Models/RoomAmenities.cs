using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab13_AsyncInn.Models
{
    public class RoomAmenities
    {
        [Display(Name ="Amenities")]
        public int AmenitiesId { get; set; }
        [Display(Name ="Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public Amenities Amenities { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab13_AsyncInn.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required]
        [StringLength(15, ErrorMessage ="15 characters or less required")]
        public string Name { get; set; }
        [DisplayName("Layout name")]
        public int LayoutId { get; set; }
        public ICollection<HotelRoom> Hotels { get; set; }
        public ICollection<RoomAmenities> Amenities { get; set; }
        public Layout Layout { get; set; }
    }
}

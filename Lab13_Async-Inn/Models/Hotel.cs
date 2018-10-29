using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab13_AsyncInn.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        [Required(ErrorMessage ="Please provide a hotel name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please provide a hotel address")]
        public string Address { get; set; }
        [Phone]
        [Required(ErrorMessage ="Please provide a hotel phone number")]
        public string Phone { get; set; }
        public ICollection<HotelRoom> Rooms { get; set; }
    }
}

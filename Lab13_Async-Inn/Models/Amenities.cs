using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models
{
    public class Amenities
    {
        [DisplayName("Amenity")]
        [Key]
        public int AmenitiesId { get; set; }
        public string Name { get; set; }
    }
}

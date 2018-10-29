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
        // TODO Add check that roomId-amenitiesId is unique 
        [DisplayName("Amenity")]
        [Key]
        public int AmenitiesId { get; set; }
        [Required(ErrorMessage ="Please provide amenities name")]
        public string Name { get; set; }
    }
}

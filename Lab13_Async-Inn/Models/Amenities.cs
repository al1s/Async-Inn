using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models
{
    public class Amenities
    {
        [Key]
        public int AmenityId { get; set; }
        public string Name { get; set; }
    }
}

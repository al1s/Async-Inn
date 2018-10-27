using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab13_AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }
        [Required(ErrorMessage ="Please provide room number")]
        public int RoomNumber { get; set; }
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Please provide a valid price")]
        [Column("Rate", TypeName ="DECIMAL(18,4)")]
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
    }
}

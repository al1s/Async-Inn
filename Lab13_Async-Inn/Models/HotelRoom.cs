using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Lab13_AsyncInn.Models;

namespace Lab13_AsyncInn.Models
{
    public class HotelRoom
    {
        [Display(Name ="Hotel")]
        public int HotelId { get; set; }
        // TODO Add check that room number is unique inside a hotel 
        [Display(Name ="Room Number")]
        [Remote(action: "CheckRoomNumberExists", controller:"HotelAndRooms", ErrorMessage = "The room number {0} already exists")]
        public int RoomNumber { get; set; }
        [Display(Name ="Room")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Please provide a valid price")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Your rate is not accepted")]
        [Column("Rate", TypeName ="DECIMAL(18,4)")]
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab13_AsyncInn.Models
{
    public class Layout
    {
        [DisplayName("Layout name")]
        public int LayoutId { get; set; }
        [Required(ErrorMessage = "Please provide a layout name")]
        public string Name { get; set; }
        public ICollection<Room> Room { get; set; }
    }
}

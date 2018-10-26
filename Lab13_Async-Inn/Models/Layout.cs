using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models
{
    public class Layout
    {
        public int LayoutId { get; set; }
        public string Name { get; set; }
        public Room Room { get; set; }
    }
}

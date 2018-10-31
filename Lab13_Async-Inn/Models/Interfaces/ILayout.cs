using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    public interface ILayout
    {
        Task<IEnumerable<Layout>> GetLayoutAsync();
    }
}

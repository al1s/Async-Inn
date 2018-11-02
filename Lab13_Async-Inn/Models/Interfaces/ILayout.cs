using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    public interface ILayout
    {
        /// <summary>
        /// Get layout from repository
        /// </summary>
        /// <returns>Enumerable of layouts</returns>
        Task<IEnumerable<Layout>> GetLayoutAsync();
    }
}

using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Services
{
    public class LayoutService : ILayout
    {
        private AsyncInnDbContext _context;
        public LayoutService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Layout>> GetLayoutAsync()
        {
            return await _context.Layouts.ToListAsync<Layout>();
        }
    }
}

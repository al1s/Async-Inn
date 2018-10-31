using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Services
{
    public class HotelService : IHotel
    {
        private readonly AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task CreateHotel(Hotel hotel)
        {

            _context.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotelAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotelById(int? id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(m => m.HotelId == id);
        }

        public bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.HotelId == id);
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}

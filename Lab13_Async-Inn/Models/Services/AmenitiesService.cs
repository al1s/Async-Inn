using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab13_AsyncInn.Models.Services
{
    public class AmenitiesService : IAmenities
    {
        private readonly AsyncInnDbContext _context;

        public AmenitiesService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenities(Amenities amenities)
        {

            _context.Add(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenities(Amenities amenities)
        {
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Amenities>> GetAmenitiesAsync()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenitiesById(int? id)
        {
            return await _context.Amenities
                .FirstOrDefaultAsync(m => m.AmenitiesId == id);
        }

        public async Task UpdateAmenities(Amenities amenities)
        {
            _context.Update(amenities);
            await _context.SaveChangesAsync();
        }
        public bool AmenitiesExists(int id)
        {
            return _context.Amenities.Any(e => e.AmenitiesId == id);
        }
    }
}

using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Services
{
    public class RoomService : IRoom
    {
        private readonly AsyncInnDbContext _context;

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(Room room)
        {

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomAsync()
        {
            return await _context.Rooms.Include(r => r.Layout).ToListAsync<Room>();
        }

        public async Task<Room> GetRoomById(int? id)
        {
                return await _context.Rooms
                .Include(r => r.Layout)
                .FirstOrDefaultAsync(m => m.RoomId == id);
        }

        public bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomId == id);
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}

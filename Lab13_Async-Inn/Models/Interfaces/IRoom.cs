using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        Task CreateRoom(Room room);
        Task<IEnumerable<Room>> GetRoomAsync();
        Task<Room> GetRoomById(int? id);
        Task UpdateRoom(Room room);
        Task DeleteRoom(Room room);
        bool RoomExists(int id);
    }
}

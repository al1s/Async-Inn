using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        /// <summary>
        /// Create room in repository
        /// </summary>
        /// <param name="room">Room to create</param>
        Task CreateRoom(Room room);
        /// <summary>
        /// Get room from repository
        /// </summary>
        /// <returns>Enumerable of room</returns>
        Task<IEnumerable<Room>> GetRoomAsync();
        /// <summary>
        /// Get room from repository by id
        /// </summary>
        /// <param name="id">id of room</param>
        Task<Room> GetRoomById(int? id);
        /// <summary>
        /// Update room
        /// </summary>
        /// <param name="room">Room to be updated</param>
        Task UpdateRoom(Room room);
        /// <summary>
        /// Delete room
        /// </summary>
        /// <param name="room"></param>
        Task DeleteRoom(Room room);
        /// <summary>
        /// Check whether room are exists
        /// </summary>
        /// <param name="id"></param>
        bool RoomExists(int id);
    }
}

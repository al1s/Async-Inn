using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        /// <summary>
        /// Create hotel in repository
        /// </summary>
        /// <param name="hotel">Hotel to create</param>
        /// <returns>Async task</returns>
        Task CreateHotel(Hotel hotel);
        /// <summary>
        /// Get hotel from repository
        /// </summary>
        /// <returns>Enumerable of hotel</returns>
        Task<IEnumerable<Hotel>> GetHotelAsync();
        /// <summary>
        /// Get hotel from repository by id
        /// </summary>
        /// <param name="id">id of hotel</param>
        Task<Hotel> GetHotelById(int? id);
        /// <summary>
        /// Update hotel
        /// </summary>
        /// <param name="hotel">Hotel to be updated</param>
        Task UpdateHotel(Hotel hotel);
        /// <summary>
        /// Delete hotel
        /// </summary>
        /// <param name="hotel"></param>
        Task DeleteHotel(Hotel hotel);
        /// <summary>
        /// Check whether hotel are exists
        /// </summary>
        /// <param name="id"></param>
        bool HotelExists(int id);
    }
}

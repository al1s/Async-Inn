using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    public interface IAmenities
    {
        /// <summary>
        /// Create amenities in repository
        /// </summary>
        /// <param name="amenities">Amenities to create</param>
        /// <returns>Async task</returns>
        Task CreateAmenities(Amenities amenities);
        /// <summary>
        /// Get amenities from repository
        /// </summary>
        /// <returns>Enumerable of amenities</returns>
        Task<IEnumerable<Amenities>> GetAmenitiesAsync();
        /// <summary>
        /// Get amenities from repository by id
        /// </summary>
        /// <param name="id">id of amenities</param>
        /// <returns>Amenities</returns>
        Task<Amenities> GetAmenitiesById(int? id);
        /// <summary>
        /// Update amenities
        /// </summary>
        /// <param name="amenities">Amenities to be updated</param>
        /// <returns></returns>
        Task UpdateAmenities(Amenities amenities);
        /// <summary>
        /// Delete amenities
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        Task DeleteAmenities(Amenities amenities);
        /// <summary>
        /// Check whether amenities are exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool AmenitiesExists(int id);
    }
}

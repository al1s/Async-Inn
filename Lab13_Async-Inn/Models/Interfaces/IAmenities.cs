using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    public interface IAmenities
    {
        Task CreateAmenities(Amenities amenities);
        Task<IEnumerable<Amenities>> GetAmenitiesAsync();
        Task<Amenities> GetAmenitiesById(int? id);
        Task UpdateAmenities(Amenities amenities);
        Task DeleteAmenities(Amenities amenities);
        bool AmenitiesExists(int id);
    }
}

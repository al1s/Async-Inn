using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        Task CreateHotel(Hotel hotel);
        Task<IEnumerable<Hotel>> GetHotelAsync();
        Task<Hotel> GetHotelById(int? id);
        Task UpdateHotel(Hotel hotel);
        Task DeleteHotel(Hotel hotel);
        bool HotelExists(int id);
    }
}

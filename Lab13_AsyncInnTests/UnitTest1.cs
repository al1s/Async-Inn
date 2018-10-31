using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Lab13_AsyncInnTests
{
    public class UnitTest1
    {
        [Fact]
        public async void CanGetHotelNameFromDb()
        {
            // setup our db context
            // set value
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelNameFromDb")
                .Options;

            new DbContextOptionsBuilder<AsyncInnDbContext>();


            // get the name into a var
            // assert var == value
            using(AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "Rainier";
                hotel.Address = "5000ft above sea";

                context.Hotels.Add(hotel);
                var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);
                Assert.Equal("Rainier", hotelName.Name);
            }
        }
        [Fact]
        public void CanSetHotelName()
        {

        }
        [Fact]
        public void CanGetHotelName()
        {

        }
    }
}

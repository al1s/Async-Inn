using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;

namespace Lab13_AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomAmenities>().HasKey(ra => new { ra.AmenitiesId, ra.RoomId });
            modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelId, hr.RoomNumber });

            modelBuilder.Entity<Layout>().HasData(
                new Layout {  LayoutId = 1, Name = "Studio" },
                new Layout {  LayoutId = 2, Name = "One bedroom" },
                new Layout {  LayoutId = 3, Name = "Two bedroom" }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Name = "Hilton Seattle", Address = "226 Aurora Ave N, Seattle, WA 98109 - 5007", HotelId=1, Phone="+ 1 877 - 859 - 5095" },
                new Hotel { Name = "Mediterranean Inn", Address = "425 Queen Anne Avenue North, Seattle, WA 98109 - 4517", HotelId=2, Phone="(206) 429 - 8799" },
                new Hotel { Name = "Belltown Inn", Address = "2301 3rd Ave, Seattle, WA 98121 - 1711", HotelId=3, Phone="(206) 203 - 7040" },
                new Hotel { Name = "Staybridge Suites Seattle", Address = "3926 Aurora Ave N, Seattle, WA 98103 - 7802", HotelId=4, Phone= "+1 877-859-5095" },
                new Hotel { Name = "Silver Cloud Inn", Address = "1150 Fairview Ave N, Seattle, WA 98109 - 4433", HotelId=5, Phone="(206) 429 - 8799" }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room { RoomId = 1, LayoutId = 1, Name = "Single" },
                new Room { RoomId = 2, LayoutId = 1, Name = "Double" },
                new Room { RoomId = 3, LayoutId = 2, Name = "Triple" },
                new Room { RoomId = 4, LayoutId = 3, Name = "Queen" },
                new Room { RoomId = 5, LayoutId = 3, Name = "King" },
                new Room { RoomId = 6, LayoutId = 2, Name = "Twin" } 
                );
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities { Name= "Kitchen facilities", AmenitiesId=1 },
                new Amenities { Name= "Computer and Internet access", AmenitiesId=2 },
                new Amenities { Name= "Swimming pool", AmenitiesId=3 },
                new Amenities { Name="Parking", AmenitiesId=4 },
                new Amenities { Name="Air conditioner", AmenitiesId=5 }
                );
        }
    }
}

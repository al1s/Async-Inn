using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Lab13_AsyncInnTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Can CRUD to Hotel table
        /// </summary>
        [Fact]
        public async void CanGetHotelNameFromDb()
        {
            // setup our db context
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelNameFromDb")
                .Options;

            Hotel hotel = new Hotel();
            // CREATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                hotel.Name = "Rainier";
                hotel.Address = "5000ft above sea";
                context.Hotels.Add(hotel);
                context.SaveChanges();
            }

            // READ: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == "Rainier");
                Assert.Equal("Rainier", hotelName.Name);
            }

            // UPDATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                hotel.Name = "Seattle";
                context.Update(hotel);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == "Seattle");
                Assert.Equal("Seattle", hotel.Name);
            }

            // DELETE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                context.Remove(hotel);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var hotelNew = context.Hotels.Count();
                Assert.Equal(0, hotelNew);
            }
        }
        /// <summary>
        /// Can read/write to Room table
        /// </summary>
        [Fact]
        public async void CanGetRoomNameFromDb()
        {
            // setup our db context
            // set value
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomNameFromDb")
                .Options;
            Room room = new Room();
            // CREATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                room.Name = "Rainier";
                context.Rooms.Add(room);
                context.SaveChanges();
            }

            // READ: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.Rooms.FirstOrDefaultAsync(x => x.Name == "Rainier");
                Assert.Equal("Rainier", entity.Name);
            }

            // UPDATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                room.Name = "Seattle";
                context.Update(room);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.Rooms.FirstOrDefaultAsync(x => x.Name == "Seattle");
                Assert.Equal("Seattle", entity.Name);
            }

            // DELETE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                context.Remove(room);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = context.Rooms.Count();
                Assert.Equal(0, entity);
            }
        }
        /// <summary>
        /// Can read/write to Amenities table
        /// </summary>
        [Fact]
        public async void CanGetAmenitiesNameFromDb()
        {
            // setup our db context
            // set value
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetAmenitiesFromDb")
                .Options;
            Amenities amenities = new Amenities();
            // CREATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                amenities.Name = "Rainier";
                context.Amenities.Add(amenities);
                context.SaveChanges();
            }

            // READ: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.Amenities.FirstOrDefaultAsync(x => x.Name == "Rainier");
                Assert.Equal("Rainier", entity.Name);
            }

            // UPDATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                amenities.Name = "Seattle";
                context.Update(amenities);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.Amenities.FirstOrDefaultAsync(x => x.Name == "Seattle");
                Assert.Equal("Seattle", entity.Name);
            }

            // DELETE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                context.Remove(amenities);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = context.Amenities.Count();
                Assert.Equal(0, entity);
            }
        }
        /// <summary>
        /// Can read/write to Layout table
        /// </summary>
        [Fact]
        public async void CanGetLayoutFromDb()
        {
            // setup our db context
            // set value
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetLayoutFromDb")
                .Options;
            Layout layout = new Layout();
            // CREATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                layout.Name = "Rainier";
                context.Layouts.Add(layout);
                context.SaveChanges();
            }

            // READ: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.Layouts.FirstOrDefaultAsync(x => x.Name == "Rainier");
                Assert.Equal("Rainier", entity.Name);
            }

            // UPDATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                layout.Name = "Seattle";
                context.Update(layout);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.Layouts.FirstOrDefaultAsync(x => x.Name == "Seattle");
                Assert.Equal("Seattle", entity.Name);
            }

            // DELETE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                context.Remove(layout);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = context.Layouts.Count();
                Assert.Equal(0, entity);
            }
        }
        /// <summary>
        /// Can read/write to HotelRooms table
        /// </summary>
        [Fact]
        public async void CanGetHotelRoomsFromDb()
        {
            // setup our db context
            // set value
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelRoomsFromDb")
                .Options;
            HotelRoom hotelRoom = new HotelRoom();
            // CREATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                hotelRoom.RoomNumber = 222;
                context.HotelRooms.Add(hotelRoom);
                context.SaveChanges();
            }

            // READ: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.HotelRooms.FirstOrDefaultAsync(x => x.RoomNumber == 222);
                Assert.Equal(222, entity.RoomNumber);
            }

            // DELETE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                context.Remove(hotelRoom);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = context.HotelRooms.Count();
                Assert.Equal(0, entity);
            }
        }
        /// <summary>
        /// Can update to HotelRooms table
        /// </summary>
        [Fact]
        public async void CanUpdateHotelRoomsFromDb()
        {
            // setup our db context
            // set value
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelRoomsUpdateFromDb")
                .Options;
            HotelRoom hotelRoom = new HotelRoom();
            // UPDATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                hotelRoom.RoomNumber = 999;
                context.Update(hotelRoom);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.HotelRooms.FirstOrDefaultAsync(x => x.RoomNumber == 999);
                Assert.Equal(999, entity.RoomNumber);
            }
        }
        /// <summary>
        /// Can read/write to room-amenities table
        /// </summary>
        [Fact]
        public async void CanGetRoomAmenitiesFromDb()
        {
            // setup our db context
            // set value
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomAmenitiesFromDb")
                .Options;
            RoomAmenities roomAmenities = new RoomAmenities();
            // CREATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                roomAmenities.AmenitiesId = 100;
                roomAmenities.RoomId = 100;
                context.RoomAmenities.Add(roomAmenities);
                context.SaveChanges();
            }

            // READ: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomId == 100);
                Assert.Equal(100, entity.RoomId);
            }


            // DELETE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                context.Remove(roomAmenities);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = context.RoomAmenities.Count();
                Assert.Equal(0, entity);
            }
        }
        /// <summary>
        /// Can update to HotelRooms table
        /// </summary>
        [Fact]
        public async void CanUpdateRoomAmenitiesFromDb()
        {
            // setup our db context
            // set value
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomAmenitiesUpdateFromDb")
                .Options;
            RoomAmenities roomAmenities = new RoomAmenities();

            // UPDATE: use a clean context instance for test
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                roomAmenities.RoomId = 999;
                context.Update(roomAmenities);
                context.SaveChanges();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                var entity = await context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomId == 999);
                Assert.Equal(999, entity.RoomId);
            }
        }





        /// <summary>
        /// Can set hotel name
        /// </summary>
        [Fact]
        public void CanSetHotelName()
        {
            Hotel hotel = new Hotel()
            {
                Name = "MyHotel",
                Address = "MyAddress",
                Phone = "MyPhone"
            };
            Assert.Equal("MyHotel", hotel.Name);
            Assert.Equal("MyAddress", hotel.Address);
            Assert.Equal("MyPhone", hotel.Phone);
        }
        /// <summary>
        /// Can get hotel name
        /// </summary>
        [Fact]
        public void CanGetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "MyHotel";
            Assert.Equal("MyHotel", hotel.Name);
        }
        /// <summary>
        /// Can set room name
        /// </summary>
        [Fact]
        public void CanSetRoomName()
        {
            Room room = new Room()
            {
                Name = "MyRoom"
            };
            Assert.Equal("MyRoom", room.Name);
        }
        /// <summary>
        /// Can get room name
        /// </summary>
        [Fact]
        public void CanGetRoomName()
        {
            Room room = new Room();
            room.Name = "MyRoom";
            Assert.Equal("MyRoom", room.Name);
        }
        /// <summary>
        /// Can set amenities
        /// </summary>
        [Fact]
        public void CanSetAmenities()
        {
            Amenities amenities = new Amenities()
            {
                Name = "MyAmenities"
            };
            Assert.Equal("MyAmenities", amenities.Name);
        }
        /// <summary>
        /// Can get room name
        /// </summary>
        [Fact]
        public void CanGetAmenities()
        {
            Amenities amenities = new Amenities()
            {
                Name = "MyAmenities"
            };
            Assert.Equal("MyAmenities", amenities.Name);
        }
        /// <summary>
        /// Can set Layouts
        /// </summary>
        [Fact]
        public void CanSetLayouts()
        {
            Layout layout = new Layout()
            {
                Name = "MyLayout",
            };
            Assert.Equal("MyLayout", layout.Name);
        }
        /// <summary>
        /// Can get Layouts
        /// </summary>
        [Fact]
        public void CanGetLayouts()
        {
            Layout layout = new Layout()
            {
                Name = "MyLayout",
            };
            Assert.Equal("MyLayout", layout.Name);
        }
        /// <summary>
        /// Can set amenities in rooms
        /// </summary>
        [Fact]
        public void CanSetRoomAmenities()
        {
            RoomAmenities roomAmenities = new RoomAmenities()
            {
                RoomId = 100,
                AmenitiesId = 500
            };
            Assert.Equal(500, roomAmenities.AmenitiesId);
            Assert.Equal(100, roomAmenities.RoomId);
        }
        /// <summary>
        /// Can get amenities in rooms
        /// </summary>
        [Fact]
        public void CanGetRoomAmenities()
        {
            RoomAmenities roomAmenities = new RoomAmenities()
            {
                RoomId = 100,
                AmenitiesId = 500
            };
            Assert.Equal(500, roomAmenities.AmenitiesId);
            Assert.Equal(100, roomAmenities.RoomId);
        }
        /// <summary>
        /// Can set rooms in hotels
        /// </summary>
        [Fact]
        public void CanSetHotelRooms()
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                RoomNumber = 1,
                RoomId = 1,
                HotelId = 1
            };
            Assert.Equal(1, hotelRoom.HotelId);
            Assert.Equal(1, hotelRoom.RoomId);
            Assert.Equal(1, hotelRoom.RoomNumber);
        }
        /// <summary>
        /// Can get rooms in hotels
        /// </summary>
        [Fact]
        public void CanGetHotelRooms()
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                RoomNumber = 1,
                RoomId = 1,
                HotelId = 1
            };
            Assert.Equal(1, hotelRoom.HotelId);
            Assert.Equal(1, hotelRoom.RoomId);
            Assert.Equal(1, hotelRoom.RoomNumber);
        }
    }
}

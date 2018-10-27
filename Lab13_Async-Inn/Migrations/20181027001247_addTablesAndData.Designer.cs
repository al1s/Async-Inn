﻿// <auto-generated />
using Lab13_AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab13_AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20181027001247_addTablesAndData")]
    partial class addTablesAndData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab13_AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("AmenitiesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("AmenitiesId");

                    b.ToTable("Amenities");

                    b.HasData(
                        new { AmenitiesId = 1, Name = "Kitchen facilities" },
                        new { AmenitiesId = 2, Name = "Computer and Internet access" },
                        new { AmenitiesId = 3, Name = "Swimming pool" },
                        new { AmenitiesId = 4, Name = "Parking" },
                        new { AmenitiesId = 5, Name = "Air conditioner" }
                    );
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new { HotelId = 1, Address = "226 Aurora Ave N, Seattle, WA 98109 - 5007", Name = "Hilton Seattle", Phone = "+ 1 877 - 859 - 5095" },
                        new { HotelId = 2, Address = "425 Queen Anne Avenue North, Seattle, WA 98109 - 4517", Name = "Mediterranean Inn", Phone = "(206) 429 - 8799" },
                        new { HotelId = 3, Address = "2301 3rd Ave, Seattle, WA 98121 - 1711", Name = "Belltown Inn", Phone = "(206) 203 - 7040" },
                        new { HotelId = 4, Address = "3926 Aurora Ave N, Seattle, WA 98103 - 7802", Name = "Staybridge Suites Seattle", Phone = "+1 877-859-5095" },
                        new { HotelId = 5, Address = "1150 Fairview Ave N, Seattle, WA 98109 - 4433", Name = "Silver Cloud Inn", Phone = "(206) 429 - 8799" }
                    );
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelId");

                    b.Property<int>("RoomNumber");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate")
                        .HasColumnName("Rate")
                        .HasColumnType("DECIMAL(18,4)");

                    b.Property<int>("RoomId");

                    b.HasKey("HotelId", "RoomNumber");

                    b.HasIndex("RoomId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.Layout", b =>
                {
                    b.Property<int>("LayoutId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("LayoutId");

                    b.ToTable("Layouts");

                    b.HasData(
                        new { LayoutId = 1, Name = "Studio" },
                        new { LayoutId = 2, Name = "One bedroom" },
                        new { LayoutId = 3, Name = "Two bedroom" }
                    );
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LayoutId");

                    b.Property<string>("Name");

                    b.HasKey("RoomId");

                    b.HasIndex("LayoutId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new { RoomId = 1, LayoutId = 1, Name = "Single" },
                        new { RoomId = 2, LayoutId = 1, Name = "Double" },
                        new { RoomId = 3, LayoutId = 2, Name = "Triple" },
                        new { RoomId = 4, LayoutId = 3, Name = "Queen" },
                        new { RoomId = 5, LayoutId = 3, Name = "King" },
                        new { RoomId = 6, LayoutId = 2, Name = "Twin" }
                    );
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesId");

                    b.Property<int>("RoomId");

                    b.HasKey("AmenitiesId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("Lab13_AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lab13_AsyncInn.Models.Room", "Room")
                        .WithMany("Hotels")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.Room", b =>
                {
                    b.HasOne("Lab13_AsyncInn.Models.Layout", "Layout")
                        .WithMany("Room")
                        .HasForeignKey("LayoutId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("Lab13_AsyncInn.Models.Amenities", "Amenities")
                        .WithMany()
                        .HasForeignKey("AmenitiesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lab13_AsyncInn.Models.Room", "Room")
                        .WithMany("Amenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
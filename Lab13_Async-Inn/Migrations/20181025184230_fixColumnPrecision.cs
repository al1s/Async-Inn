using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab13_AsyncInn.Migrations
{
    public partial class fixColumnPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Rooms_RoomId1",
                table: "HotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_RoomId1",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "HotelRooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "HotelRooms",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "HotelRooms",
                type: "DECIMAL(18,4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomId",
                table: "HotelRooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Rooms_RoomId",
                table: "HotelRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Rooms_RoomId",
                table: "HotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_RoomId",
                table: "HotelRooms");

            migrationBuilder.AlterColumn<decimal>(
                name: "RoomId",
                table: "HotelRooms",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "HotelRooms",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,4)");

            migrationBuilder.AddColumn<int>(
                name: "RoomId1",
                table: "HotelRooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomId1",
                table: "HotelRooms",
                column: "RoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Rooms_RoomId1",
                table: "HotelRooms",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

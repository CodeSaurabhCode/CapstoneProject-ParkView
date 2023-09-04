using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkViewServices.Migrations
{
    public partial class BookingtheRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildrenBelow7 = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren7To12 = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpecialRequests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckOutTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalGuestInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CancellationPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingRooms",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRooms", x => new { x.BookingId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_BookingRooms_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRooms_RoomId",
                table: "BookingRooms",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRooms");

            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}

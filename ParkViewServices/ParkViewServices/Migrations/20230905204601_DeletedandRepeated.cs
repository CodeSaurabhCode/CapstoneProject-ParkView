using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkViewServices.Migrations
{
    public partial class DeletedandRepeated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookedList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildrenBelow7 = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren7To12 = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PromoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookedListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_BookedList_BookedListId",
                        column: x => x.BookedListId,
                        principalTable: "BookedList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalRooms = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelImages_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomCount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Occupied = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomCount_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomCount_RoomTypes_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    BedCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingCartRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    BookingCartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCartRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingCartRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "India" },
                    { 2, "Maldives" },
                    { 3, "Thailand" },
                    { 4, "China" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Description", "Price", "RoomTypeName" },
                values: new object[,]
                {
                    { 1, "Luxurious and spacious presidential suite", 28000, "Presidential Suite" },
                    { 2, "Elegant executive room with modern amenities", 20000, "Executive" },
                    { 3, "Comfortable and stylish deluxe room", 16000, "Deluxe" },
                    { 4, "Superior deluxe room for a premium stay", 8000, "Super Deluxe" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "New Delhi" },
                    { 2, 1, "Mumbai" },
                    { 3, 2, "Male" },
                    { 4, 3, "Bangkok" },
                    { 5, 4, "Beijing" },
                    { 6, 1, "Chennai" },
                    { 7, 1, "Kolkata" },
                    { 8, 2, "Colombo" },
                    { 9, 3, "Phuket" },
                    { 10, 4, "Shanghai" }
                });

            migrationBuilder.InsertData(
                table: "RoomImages",
                columns: new[] { "Id", "Caption", "ImagePath", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, "Deluxe Room", "~/Images/room10.jpeg", 1 },
                    { 2, "Deluxe Room Bathroom", "~/Images/room12.jpeg", 1 },
                    { 3, "Super Deluxe Room", "~/Images/room20.jpeg", 2 },
                    { 4, "Super Deluxe Room View", "~/Images/room22.jpeg", 2 },
                    { 5, "Executive Suite", "~/Images/Hotel30.jpeg", 3 },
                    { 6, "Executive Suite Living Area", "~/Images/Hotel32.jpeg", 3 },
                    { 7, "Presidential Suite", "~/Images/Hotel40.jpeg", 4 },
                    { 8, "Presidential Suite Bedroom", "~/Images/Hotel42.jpeg", 4 }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CityId", "Description", "Email", "Name", "PhoneNumber", "TotalRooms" },
                values: new object[,]
                {
                    { 1, "123 Main Street, New Delhi", 1, "A luxurious oasis in the heart of New Delhi", "info@opulentoasis.com", "Opulent Oasis Retreat", "+91-XXX-XXXXXXX", 40 },
                    { 2, "456 Park Avenue, New Delhi", 1, "Experience the celestial luxury in New Delhi", "info@celestialmirage.com", "Celestial Mirage Hotel", "+91-XXX-XXXXXXX", 50 },
                    { 3, "789 Beach Road, Mumbai", 2, "Exclusive suites by the azure waves", "info@azurewaves.com", "Azure Waves Suites", "+91-XXX-XXXXXXX", 80 },
                    { 4, "101 Downtown Avenue, Mumbai", 2, "Discover bliss in the heart of Mumbai", "info@blissfulhaven.com", "Mumbai Blissful Haven", "+91-XXX-XXXXXXX", 30 },
                    { 5, "456 Island Beach, Male", 3, "A beachfront paradise in the Maldives", "info@tropicalparadise.com", "Tropical Paradise Resort", "+960-XXXXXXX", 50 },
                    { 6, "789 Riverside Road, Bangkok", 4, "Elysium by the scenic riverside in Bangkok", "info@riversideelysium.com", "Riverside Elysium Hotel", "+66-XX-XXXXXXX", 90 },
                    { 7, "321 Downtown Plaza, Bangkok", 4, "Urban comfort under sapphire skies in Bangkok", "info@sapphireskies.com", "Sapphire Skies Hotel", "+66-XX-XXXXXXX", 75 },
                    { 8, "101 Forbidden City Avenue, Beijing", 5, "Historic luxury near the Forbidden City", "info@imperialpalace.com", "Imperial Palace Beijing", "+86-XXX-XXXXXXX", 150 },
                    { 9, "789 Wangfujing Street, Beijing", 5, "A downtown haven in the heart of Beijing", "info@downtownhaven.com", "Beijing Downtown Haven", "+86-XXX-XXXXXXX", 100 },
                    { 10, "456 Park Road, Kolkata", 7, "Elegant luxury at Kolkata Grand Plaza", "info@grandplaza.com", "Kolkata Grand Plaza", "+91-XXX-XXXXXXX", 80 },
                    { 11, "789 Oceanfront Drive, Colombo", 8, "Find bliss by the Colombo beach", "info@beachbliss.com", "Colombo Beach Bliss", "+94-XX-XXXXXXX", 60 },
                    { 12, "101 Tropical Lane, Phuket", 9, "Private villa paradise in Phuket", "info@paradisevilla.com", "Phuket Paradise Villa", "+66-XX-XXXXXXX", 40 },
                    { 13, "123 Pudong Avenue, Shanghai", 10, "Sanctuary with a view of the Shanghai skyline", "info@skylinesanctuary.com", "Shanghai Skyline Sanctuary", "+86-XXX-XXXXXXX", 120 }
                });

            migrationBuilder.InsertData(
                table: "HotelImages",
                columns: new[] { "Id", "Caption", "HotelId", "ImagePath" },
                values: new object[,]
                {
                    { 1, "Hotel Lobby", 1, "~/Images/Hotel1.jpeg" },
                    { 2, "Pool Area", 1, "~/Images/Hotel12.jpeg" },
                    { 3, "Deluxe Room", 2, "~/Images/Hotel2.jpeg" },
                    { 4, "Restaurant", 2, "~/Images/Hotel22.jpeg" },
                    { 5, "Deluxe Room", 3, "~/Images/Hotel3.jpeg" },
                    { 6, "Restaurant", 3, "~/Images/Hotel32.jpeg" },
                    { 7, "Deluxe Room", 4, "~/Images/Hotel4.jpeg" },
                    { 8, "Restaurant", 4, "~/Images/Hotel42.jpeg" },
                    { 9, "Deluxe Room", 5, "~/Images/Hotel5.jpeg" },
                    { 10, "Restaurant", 5, "~/Images/Hotel52.jpeg" },
                    { 11, "Deluxe Room", 6, "~/Images/Hotel6.jpeg" },
                    { 12, "Restaurant", 6, "~/Images/Hotel62.jpeg" },
                    { 13, "Deluxe Room", 7, "~/Images/Hotel7.jpeg" },
                    { 14, "Restaurant", 7, "~/Images/Hotel72.jpeg" },
                    { 15, "Deluxe Room", 8, "~/Images/Hotel8.jpeg" },
                    { 16, "Restaurant", 8, "~/Images/Hotel82.jpeg" },
                    { 17, "Deluxe Room", 9, "~/Images/Hotel9.jpeg" },
                    { 18, "Restaurant", 9, "~/Images/Hotel92.jpeg" },
                    { 19, "Deluxe Room", 10, "~/Images/Hotel10.jpeg" },
                    { 20, "Restaurant", 10, "~/Images/Hotel102.jpeg" },
                    { 21, "Deluxe Room", 11, "~/Images/Hotel11.jpeg" },
                    { 22, "Restaurant", 11, "~/Images/Hotel112.jpeg" },
                    { 23, "Deluxe Room", 12, "~/Images/Hotel12.jpeg" },
                    { 24, "Restaurant", 12, "~/Images/Hotel122.jpeg" },
                    { 25, "Deluxe Room", 13, "~/Images/Hotel13.jpeg" },
                    { 26, "Restaurant", 13, "~/Images/Hotel132.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "RoomCount",
                columns: new[] { "Id", "Count", "HotelID", "Occupied", "RoomTypeID" },
                values: new object[,]
                {
                    { 1, 5, 1, 0, 1 },
                    { 2, 10, 1, 0, 2 },
                    { 3, 15, 1, 0, 3 },
                    { 4, 10, 1, 0, 4 },
                    { 5, 3, 2, 0, 1 },
                    { 6, 7, 2, 0, 2 },
                    { 7, 20, 2, 0, 3 },
                    { 8, 20, 2, 0, 4 },
                    { 9, 10, 3, 0, 1 },
                    { 10, 30, 3, 0, 2 },
                    { 11, 20, 3, 0, 3 },
                    { 12, 20, 3, 0, 4 },
                    { 13, 3, 4, 0, 1 },
                    { 14, 8, 4, 0, 2 },
                    { 15, 9, 4, 0, 3 },
                    { 16, 10, 4, 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "RoomCount",
                columns: new[] { "Id", "Count", "HotelID", "Occupied", "RoomTypeID" },
                values: new object[,]
                {
                    { 17, 2, 5, 0, 1 },
                    { 18, 12, 5, 0, 2 },
                    { 19, 20, 5, 0, 3 },
                    { 20, 8, 5, 0, 4 },
                    { 21, 3, 6, 0, 1 },
                    { 22, 18, 6, 0, 2 },
                    { 23, 28, 6, 0, 3 },
                    { 24, 21, 6, 0, 4 },
                    { 25, 7, 7, 0, 1 },
                    { 26, 25, 7, 0, 2 },
                    { 27, 40, 7, 0, 3 },
                    { 28, 28, 7, 0, 4 },
                    { 29, 5, 8, 0, 1 },
                    { 30, 15, 8, 0, 2 },
                    { 31, 25, 8, 0, 3 },
                    { 32, 30, 8, 0, 4 },
                    { 33, 8, 9, 0, 1 },
                    { 34, 30, 9, 0, 2 },
                    { 35, 40, 9, 0, 3 },
                    { 36, 22, 9, 0, 4 },
                    { 37, 5, 10, 0, 1 },
                    { 38, 15, 10, 0, 2 },
                    { 39, 20, 10, 0, 3 },
                    { 40, 40, 10, 0, 4 },
                    { 41, 5, 11, 0, 1 },
                    { 42, 15, 11, 0, 2 },
                    { 43, 20, 11, 0, 3 },
                    { 44, 40, 11, 0, 4 },
                    { 45, 2, 12, 0, 1 },
                    { 46, 5, 12, 0, 2 },
                    { 47, 13, 12, 0, 3 },
                    { 48, 20, 12, 0, 4 },
                    { 49, 5, 13, 0, 1 },
                    { 50, 15, 13, 0, 2 },
                    { 51, 20, 13, 0, 3 },
                    { 52, 40, 13, 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedCount", "HotelId", "RoomName", "RoomNumber", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, "Presidential Suite 101", 101, 4, false },
                    { 2, 1, 1, "Presidential Suite 102", 102, 4, false },
                    { 3, 1, 1, "Presidential Suite 103", 103, 4, false },
                    { 4, 1, 1, "Presidential Suite 104", 104, 4, false },
                    { 5, 1, 1, "Presidential Suite 105", 105, 4, false },
                    { 6, 1, 1, "Executive Suite 201", 201, 3, false }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedCount", "HotelId", "RoomName", "RoomNumber", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { 7, 1, 1, "Executive Suite 202", 202, 3, false },
                    { 8, 1, 1, "Executive Suite 203", 203, 3, false },
                    { 9, 1, 1, "Executive Suite 204", 204, 3, false },
                    { 10, 1, 1, "Executive Suite 205", 205, 3, false },
                    { 11, 1, 1, "Executive Suite 206", 206, 3, false },
                    { 12, 1, 1, "Executive Suite 207", 207, 3, false },
                    { 13, 1, 1, "Executive Suite 208", 208, 3, false },
                    { 14, 1, 1, "Executive Suite 209", 209, 3, false },
                    { 15, 1, 1, "Executive Suite 210", 210, 3, false },
                    { 16, 2, 1, "Deluxe Room 301", 301, 1, false },
                    { 17, 2, 1, "Deluxe Room 302", 302, 1, false },
                    { 18, 2, 1, "Deluxe Room 303", 303, 1, false },
                    { 19, 2, 1, "Deluxe Room 304", 304, 1, false },
                    { 20, 2, 1, "Deluxe Room 305", 305, 1, false },
                    { 21, 2, 1, "Deluxe Room 306", 306, 1, false },
                    { 22, 2, 1, "Deluxe Room 307", 307, 1, false },
                    { 23, 2, 1, "Deluxe Room 308", 308, 1, false },
                    { 24, 2, 1, "Deluxe Room 309", 309, 1, false },
                    { 25, 2, 1, "Deluxe Room 310", 310, 1, false },
                    { 26, 2, 1, "Super Deluxe Room 401", 401, 2, false },
                    { 27, 2, 1, "Super Deluxe Room 402", 402, 2, false },
                    { 28, 2, 1, "Super Deluxe Room 403", 403, 2, false },
                    { 29, 2, 1, "Super Deluxe Room 404", 404, 2, false },
                    { 30, 2, 1, "Super Deluxe Room 405", 405, 2, false },
                    { 31, 2, 1, "Super Deluxe Room 406", 406, 2, false },
                    { 32, 2, 1, "Super Deluxe Room 407", 407, 2, false },
                    { 33, 2, 1, "Super Deluxe Room 408", 408, 2, false },
                    { 34, 2, 1, "Super Deluxe Room 409", 409, 2, false },
                    { 35, 2, 1, "Super Deluxe Room 410", 410, 2, false },
                    { 36, 2, 1, "Deluxe Room 311", 311, 1, false },
                    { 37, 2, 1, "Deluxe Room 312", 312, 1, false },
                    { 38, 2, 1, "Deluxe Room 313", 313, 1, false },
                    { 39, 2, 1, "Deluxe Room 314", 314, 1, false },
                    { 40, 2, 1, "Deluxe Room 315", 315, 1, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCartRooms_RoomId",
                table: "BookingCartRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookedListId",
                table: "Bookings",
                column: "BookedListId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelImages_HotelId",
                table: "HotelImages",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCount_HotelID",
                table: "RoomCount",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCount_RoomTypeID",
                table: "RoomCount",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomTypeId",
                table: "RoomImages",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookingCartRooms");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "HotelImages");

            migrationBuilder.DropTable(
                name: "RoomCount");

            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "BookedList");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Models.Rooms;

namespace ParkViewServices.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomCount> RoomCount { get; set; }
        public DbSet<RoomImages> RoomImages { get; set; }
        public DbSet<HotelImages> HotelImages { get; set; }
        public DbSet<BookedList> BookedList { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<BookingRoom> BookingRooms { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<BookingCartRoom> BookingCartRooms { get; set; }
        public DbSet<HotelSingleImage> HotelSingleImage { get; set; }
        public DbSet<CityImage> CityImage { get; set; } 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country {Id = 1, Name = "India" },
                new Country {Id = 2, Name = "Maldives" },
                new Country {Id = 3, Name = "Thailand" },
                new Country {Id = 4, Name = "China" }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, CountryId = 1 , Name = "New Delhi", },
                new City { Id = 2, CountryId = 1 ,Name = "Mumbai", },
                new City { Id = 3, CountryId = 2 ,Name = "Male", },
                new City { Id = 4, CountryId = 3 ,Name = "Bangkok", },
                new City { Id = 5, CountryId = 4 ,Name = "Beijing", },
                new City { Id = 6, CountryId = 1 ,Name = "Chennai", },
                new City { Id = 7, CountryId = 1 ,Name = "Kolkata", },
                new City { Id = 8, CountryId = 2 ,Name = "Colombo", },
                new City { Id = 9, CountryId = 3 ,Name = "Phuket", },
                new City { Id = 10, CountryId =4 ,Name = "Shanghai", }
    );

            modelBuilder.Entity<Hotel>().HasData(
                 // Hotels in New Delhi, India
                 new Hotel { Id = 1, Name = "Opulent Oasis Retreat", Address = "123 Main Street, New Delhi", PhoneNumber = "+91-XXX-XXXXXXX", Email = "info@opulentoasis.com", Description = "A luxurious oasis in the heart of New Delhi", TotalRooms = 40,  CityId = 1 },
                 new Hotel { Id = 2, Name = "Celestial Mirage Hotel", Address = "456 Park Avenue, New Delhi", PhoneNumber = "+91-XXX-XXXXXXX", Email = "info@celestialmirage.com", Description = "Experience the celestial luxury in New Delhi", TotalRooms = 50,  CityId = 1 },

                 // Hotels in Mumbai, India
                 new Hotel { Id = 3, Name = "Azure Waves Suites", Address = "789 Beach Road, Mumbai", PhoneNumber = "+91-XXX-XXXXXXX", Email = "info@azurewaves.com", Description = "Exclusive suites by the azure waves", TotalRooms = 80,  CityId = 2 },
                 new Hotel { Id = 4, Name = "Mumbai Blissful Haven", Address = "101 Downtown Avenue, Mumbai", PhoneNumber = "+91-XXX-XXXXXXX", Email = "info@blissfulhaven.com", Description = "Discover bliss in the heart of Mumbai", TotalRooms = 30,  CityId = 2 },

                 // Hotels in Male, Maldives
                 new Hotel { Id = 5, Name = "Tropical Paradise Resort", Address = "456 Island Beach, Male", PhoneNumber = "+960-XXXXXXX", Email = "info@tropicalparadise.com", Description = "A beachfront paradise in the Maldives", TotalRooms = 50,  CityId = 3 },

                 // Hotels in Bangkok, Thailand
                 new Hotel { Id = 6, Name = "Riverside Elysium Hotel", Address = "789 Riverside Road, Bangkok", PhoneNumber = "+66-XX-XXXXXXX", Email = "info@riversideelysium.com", Description = "Elysium by the scenic riverside in Bangkok", TotalRooms = 90,  CityId = 4 },
                 new Hotel { Id = 7, Name = "Sapphire Skies Hotel", Address = "321 Downtown Plaza, Bangkok", PhoneNumber = "+66-XX-XXXXXXX", Email = "info@sapphireskies.com", Description = "Urban comfort under sapphire skies in Bangkok", TotalRooms = 75,  CityId = 4 },

                 // Hotels in Beijing, China
                 new Hotel { Id = 8, Name = "Imperial Palace Beijing", Address = "101 Forbidden City Avenue, Beijing", PhoneNumber = "+86-XXX-XXXXXXX", Email = "info@imperialpalace.com", Description = "Historic luxury near the Forbidden City", TotalRooms = 150,  CityId = 5 },
                 new Hotel { Id = 9, Name = "Beijing Downtown Haven", Address = "789 Wangfujing Street, Beijing", PhoneNumber = "+86-XXX-XXXXXXX", Email = "info@downtownhaven.com", Description = "A downtown haven in the heart of Beijing", TotalRooms = 100,  CityId = 5 },

                 // Hotels in Kolkata, India
                 new Hotel { Id = 10, Name = "Kolkata Grand Plaza", Address = "456 Park Road, Kolkata", PhoneNumber = "+91-XXX-XXXXXXX", Email = "info@grandplaza.com", Description = "Elegant luxury at Kolkata Grand Plaza", TotalRooms = 80,  CityId = 7 },

                 // Hotels in Colombo, Sri Lanka
                 new Hotel { Id = 11, Name = "Colombo Beach Bliss", Address = "789 Oceanfront Drive, Colombo", PhoneNumber = "+94-XX-XXXXXXX", Email = "info@beachbliss.com", Description = "Find bliss by the Colombo beach", TotalRooms = 60,  CityId = 8 },

                 // Hotels in Phuket, Thailand
                 new Hotel { Id = 12, Name = "Phuket Paradise Villa", Address = "101 Tropical Lane, Phuket", PhoneNumber = "+66-XX-XXXXXXX", Email = "info@paradisevilla.com", Description = "Private villa paradise in Phuket", TotalRooms = 40,  CityId = 9 },

                 // Hotels in Shanghai, China
                 new Hotel { Id = 13, Name = "Shanghai Skyline Sanctuary", Address = "123 Pudong Avenue, Shanghai", PhoneNumber = "+86-XXX-XXXXXXX", Email = "info@skylinesanctuary.com", Description = "Sanctuary with a view of the Shanghai skyline", TotalRooms = 120,  CityId = 10 }
 );

            modelBuilder.Entity<RoomType>().HasData(
            new RoomType { Id = 1, RoomTypeName = "Presidential Suite", Description = "Luxurious and spacious presidential suite", Price = 28000},
            new RoomType { Id = 2, RoomTypeName = "Executive", Description = "Elegant executive room with modern amenities", Price = 20000},
            new RoomType { Id = 3, RoomTypeName = "Deluxe", Description = "Comfortable and stylish deluxe room", Price = 16000 },
            new RoomType { Id = 4, RoomTypeName = "Super Deluxe", Description = "Superior deluxe room for a premium stay", Price = 8000 }
);

            modelBuilder.Entity<RoomCount>().HasData(
                // Room counts for Opulent Oasis Retreat in New Delhi, India
                new RoomCount { Id = 1, HotelID = 1, RoomTypeID = 1, Count = 5 , Occupied = 0}, // 10 Presidential Suites
                new RoomCount { Id = 2, HotelID = 1, RoomTypeID = 2, Count = 10 , Occupied = 0}, // 20 Executive rooms
                new RoomCount { Id = 3, HotelID = 1, RoomTypeID = 3, Count = 15 , Occupied = 0}, // 40 Deluxe rooms
                new RoomCount { Id = 4, HotelID = 1, RoomTypeID = 4, Count = 10 , Occupied = 0}, // 30 Super Deluxe rooms

                // Room counts for Celestial Mirage Hotel in New Delhi, India
                new RoomCount { Id = 5, HotelID = 2, RoomTypeID = 1, Count = 3 , Occupied = 0}, // 5 Presidential Suites
                new RoomCount { Id = 6, HotelID = 2, RoomTypeID = 2, Count = 7 , Occupied = 0}, // 15 Executive rooms
                new RoomCount { Id = 7, HotelID = 2, RoomTypeID = 3, Count = 20 , Occupied = 0}, // 30 Deluxe rooms
                new RoomCount { Id = 8, HotelID = 2, RoomTypeID = 4, Count = 20 , Occupied = 0}, // 20 Super Deluxe rooms

                // Room counts for Azure Waves Suites in Mumbai, India
                new RoomCount { Id = 9, HotelID = 3, RoomTypeID = 1, Count = 10 , Occupied = 0}, // 10 Presidential Suites
                new RoomCount { Id = 10, HotelID = 3, RoomTypeID = 2, Count = 30 , Occupied = 0}, // 30 Executive rooms
                new RoomCount { Id = 11, HotelID = 3, RoomTypeID = 3, Count = 20 , Occupied = 0}, // 20 Deluxe rooms
                new RoomCount { Id = 12, HotelID = 3, RoomTypeID = 4, Count = 20 , Occupied = 0}, // 20 Super Deluxe rooms

                // Room counts for Mumbai Blissful Haven in Mumbai, India
                new RoomCount { Id = 13, HotelID = 4, RoomTypeID = 1, Count = 3 , Occupied = 0}, // 8 Presidential Suites
                new RoomCount { Id = 14, HotelID = 4, RoomTypeID = 2, Count = 8 , Occupied = 0}, // 25 Executive rooms
                new RoomCount { Id = 15, HotelID = 4, RoomTypeID = 3, Count = 9 , Occupied = 0}, // 50 Deluxe rooms
                new RoomCount { Id = 16, HotelID = 4, RoomTypeID = 4, Count = 10 , Occupied = 0}, // 27 Super Deluxe rooms

                // Room counts for Tropical Paradise Resort in Male, Maldives
                new RoomCount { Id = 17, HotelID = 5, RoomTypeID = 1, Count = 2 , Occupied = 0}, // 2 Presidential Suites
                new RoomCount { Id = 18, HotelID = 5, RoomTypeID = 2, Count = 12 , Occupied = 0}, // 12 Executive rooms
                new RoomCount { Id = 19, HotelID = 5, RoomTypeID = 3, Count = 20 , Occupied = 0}, // 20 Deluxe rooms
                new RoomCount { Id = 20, HotelID = 5, RoomTypeID = 4, Count = 8 , Occupied = 0}, // 8 Super Deluxe rooms

                // Room counts for Riverside Elysium Hotel in Bangkok, Thailand
                new RoomCount { Id = 21, HotelID = 6, RoomTypeID = 1, Count = 3 , Occupied = 0}, // 3 Presidential Suites
                new RoomCount { Id = 22, HotelID = 6, RoomTypeID = 2, Count = 18 , Occupied = 0}, // 18 Executive rooms
                new RoomCount { Id = 23, HotelID = 6, RoomTypeID = 3, Count = 28 , Occupied = 0}, // 28 Deluxe rooms
                new RoomCount { Id = 24, HotelID = 6, RoomTypeID = 4, Count = 21 , Occupied = 0}, // 21 Super Deluxe rooms

                // Room counts for Sapphire Skies Hotel in Bangkok, Thailand
                new RoomCount { Id = 25, HotelID = 7, RoomTypeID = 1, Count = 7 , Occupied = 0}, // 7 Presidential Suites
                new RoomCount { Id = 26, HotelID = 7, RoomTypeID = 2, Count = 25 , Occupied = 0}, // 25 Executive rooms
                new RoomCount { Id = 27, HotelID = 7, RoomTypeID = 3, Count = 40 , Occupied = 0}, // 40 Deluxe rooms
                new RoomCount { Id = 28, HotelID = 7, RoomTypeID = 4, Count = 28 , Occupied = 0}, // 28 Super Deluxe rooms

                // Room counts for Imperial Palace Beijing in Beijing, China
                new RoomCount { Id = 29, HotelID = 8, RoomTypeID = 1, Count = 5 , Occupied = 0}, // 5 Presidential Suites
                new RoomCount { Id = 30, HotelID = 8, RoomTypeID = 2, Count = 15 , Occupied = 0}, // 15 Executive rooms
                new RoomCount { Id = 31, HotelID = 8, RoomTypeID = 3, Count = 25 , Occupied = 0}, // 25 Deluxe rooms
                new RoomCount { Id = 32, HotelID = 8, RoomTypeID = 4, Count = 30 , Occupied = 0}, // 30 Super Deluxe rooms

                // Room counts for Beijing Downtown Haven in Beijing, China
                new RoomCount { Id = 33, HotelID = 9, RoomTypeID = 1, Count = 8 , Occupied = 0}, // 8 Presidential Suites
                new RoomCount { Id = 34, HotelID = 9, RoomTypeID = 2, Count = 30 , Occupied = 0}, // 30 Executive rooms
                new RoomCount { Id = 35, HotelID = 9, RoomTypeID = 3, Count = 40 , Occupied = 0}, // 40 Deluxe rooms
                new RoomCount { Id = 36, HotelID = 9, RoomTypeID = 4, Count = 22 , Occupied = 0}, // 22 Super Deluxe rooms

                // Room counts for Kolkata Grand Plaza in Kolkata, India
                new RoomCount { Id = 37, HotelID = 10, RoomTypeID = 1, Count = 5 , Occupied = 0}, // 5 Presidential Suites
                new RoomCount { Id = 38, HotelID = 10, RoomTypeID = 2, Count = 15 , Occupied = 0}, // 15 Executive rooms
                new RoomCount { Id = 39, HotelID = 10, RoomTypeID = 3, Count = 20 , Occupied = 0}, // 20 Deluxe rooms
                new RoomCount { Id = 40, HotelID = 10, RoomTypeID = 4, Count = 40 , Occupied = 0}, // 40 Super Deluxe rooms


                new RoomCount { Id = 41, HotelID = 11, RoomTypeID = 1, Count = 5 , Occupied = 0}, // 5 Presidential Suites
                new RoomCount { Id = 42, HotelID = 11, RoomTypeID = 2, Count = 15 , Occupied = 0}, // 15 Executive rooms
                new RoomCount { Id = 43, HotelID = 11, RoomTypeID = 3, Count = 20 , Occupied = 0}, // 20 Deluxe rooms
                new RoomCount { Id = 44, HotelID = 11, RoomTypeID = 4, Count = 40 , Occupied = 0 },

                new RoomCount { Id = 45, HotelID = 12, RoomTypeID = 1, Count = 2, Occupied = 0 }, // 5 Presidential Suites
                new RoomCount { Id = 46, HotelID = 12, RoomTypeID = 2, Count = 5, Occupied = 0 }, // 15 Executive rooms
                new RoomCount { Id = 47, HotelID = 12, RoomTypeID = 3, Count = 13, Occupied = 0 }, // 20 Deluxe rooms
                new RoomCount { Id = 48, HotelID = 12, RoomTypeID = 4, Count = 20, Occupied = 0 },

                new RoomCount { Id = 49, HotelID = 13, RoomTypeID = 1, Count = 5, Occupied = 0 }, // 5 Presidential Suites
                new RoomCount { Id = 50, HotelID = 13, RoomTypeID = 2, Count = 15, Occupied = 0 }, // 15 Executive rooms
                new RoomCount { Id = 51, HotelID = 13, RoomTypeID = 3, Count = 20, Occupied = 0 }, // 20 Deluxe rooms
                new RoomCount { Id = 52, HotelID = 13, RoomTypeID = 4, Count = 40, Occupied = 0 }

// Add room count data for other hotels, if needed
);
            modelBuilder.Entity<Room>().HasData(
                // Rooms for Opulent Oasis Retreat in New Delhi
                // Presidential Suites (5 rooms)
                new Room { Id = 1, RoomNumber = 101, RoomName = "Presidential Suite 101", RoomTypeId = 4, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 2, RoomNumber = 102, RoomName = "Presidential Suite 102", RoomTypeId = 4, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 3, RoomNumber = 103, RoomName = "Presidential Suite 103", RoomTypeId = 4, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 4, RoomNumber = 104, RoomName = "Presidential Suite 104", RoomTypeId = 4, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 5, RoomNumber = 105, RoomName = "Presidential Suite 105", RoomTypeId = 4, BedCount = 1, Status = false, HotelId = 1 },

                // Executive Suites (10 rooms)
                new Room { Id = 6, RoomNumber = 201, RoomName = "Executive Suite 201", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 7, RoomNumber = 202, RoomName = "Executive Suite 202", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 8, RoomNumber = 203, RoomName = "Executive Suite 203", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 9, RoomNumber = 204, RoomName = "Executive Suite 204", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 10, RoomNumber = 205, RoomName = "Executive Suite 205", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 11, RoomNumber = 206, RoomName = "Executive Suite 206", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 12, RoomNumber = 207, RoomName = "Executive Suite 207", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 13, RoomNumber = 208, RoomName = "Executive Suite 208", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 14, RoomNumber = 209, RoomName = "Executive Suite 209", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },
                new Room { Id = 15, RoomNumber = 210, RoomName = "Executive Suite 210", RoomTypeId = 3, BedCount = 1, Status = false, HotelId = 1 },

                // Deluxe Rooms (15 rooms)
                new Room { Id = 16, RoomNumber = 301, RoomName = "Deluxe Room 301", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 17, RoomNumber = 302, RoomName = "Deluxe Room 302", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 18, RoomNumber = 303, RoomName = "Deluxe Room 303", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 19, RoomNumber = 304, RoomName = "Deluxe Room 304", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 20, RoomNumber = 305, RoomName = "Deluxe Room 305", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 21, RoomNumber = 306, RoomName = "Deluxe Room 306", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 22, RoomNumber = 307, RoomName = "Deluxe Room 307", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 23, RoomNumber = 308, RoomName = "Deluxe Room 308", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 24, RoomNumber = 309, RoomName = "Deluxe Room 309", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 25, RoomNumber = 310, RoomName = "Deluxe Room 310", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 36, RoomNumber = 311, RoomName = "Deluxe Room 311", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 37, RoomNumber = 312, RoomName = "Deluxe Room 312", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 38, RoomNumber = 313, RoomName = "Deluxe Room 313", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 39, RoomNumber = 314, RoomName = "Deluxe Room 314", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 40, RoomNumber = 315, RoomName = "Deluxe Room 315", RoomTypeId = 1, BedCount = 2, Status = false, HotelId = 1 },

                // Super Deluxe Rooms (10 rooms)
                new Room { Id = 26, RoomNumber = 401, RoomName = "Super Deluxe Room 401", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 27, RoomNumber = 402, RoomName = "Super Deluxe Room 402", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 28, RoomNumber = 403, RoomName = "Super Deluxe Room 403", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 29, RoomNumber = 404, RoomName = "Super Deluxe Room 404", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 30, RoomNumber = 405, RoomName = "Super Deluxe Room 405", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 31, RoomNumber = 406, RoomName = "Super Deluxe Room 406", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 32, RoomNumber = 407, RoomName = "Super Deluxe Room 407", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 33, RoomNumber = 408, RoomName = "Super Deluxe Room 408", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 34, RoomNumber = 409, RoomName = "Super Deluxe Room 409", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 },
                new Room { Id = 35, RoomNumber = 410, RoomName = "Super Deluxe Room 410", RoomTypeId = 2, BedCount = 2, Status = false, HotelId = 1 }
            );

        modelBuilder.Entity<HotelImages>().HasData(
            new HotelImages { Id = 1, ImagePath = "~/Images/Hotel1.jpeg", Caption = "Hotel Lobby", HotelId = 1 },
            new HotelImages { Id = 2, ImagePath = "~/Images/Hotel12.jpeg", Caption = "Pool Area", HotelId = 1 },
            new HotelImages { Id = 3, ImagePath = "~/Images/Hotel2.jpeg", Caption = "Deluxe Room", HotelId = 2 },
            new HotelImages { Id = 4, ImagePath = "~/Images/Hotel22.jpeg", Caption = "Restaurant", HotelId = 2 },
            new HotelImages { Id = 5, ImagePath = "~/Images/Hotel3.jpeg", Caption = "Deluxe Room", HotelId = 3 },
            new HotelImages { Id = 6, ImagePath = "~/Images/Hotel32.jpeg", Caption = "Restaurant", HotelId = 3},
            new HotelImages { Id = 7, ImagePath = "~/Images/Hotel4.jpeg", Caption = "Deluxe Room", HotelId = 4 },
            new HotelImages { Id = 8, ImagePath = "~/Images/Hotel42.jpeg", Caption = "Restaurant", HotelId = 4 },
            new HotelImages { Id = 9, ImagePath = "~/Images/Hotel5.jpeg", Caption = "Deluxe Room", HotelId = 5 },
            new HotelImages { Id = 10, ImagePath = "~/Images/Hotel52.jpeg", Caption = "Restaurant", HotelId = 5 },
            new HotelImages { Id = 11, ImagePath = "~/Images/Hotel6.jpeg", Caption = "Deluxe Room", HotelId = 6 },
            new HotelImages { Id = 12, ImagePath = "~/Images/Hotel62.jpeg", Caption = "Restaurant", HotelId = 6 },
            new HotelImages { Id = 13, ImagePath = "~/Images/Hotel7.jpeg", Caption = "Deluxe Room", HotelId = 7 },
            new HotelImages { Id = 14, ImagePath = "~/Images/Hotel72.jpeg", Caption = "Restaurant", HotelId = 7 },
            new HotelImages { Id = 15, ImagePath = "~/Images/Hotel8.jpeg", Caption = "Deluxe Room", HotelId = 8 },
            new HotelImages { Id = 16, ImagePath = "~/Images/Hotel82.jpeg", Caption = "Restaurant", HotelId = 8 },
            new HotelImages { Id = 17, ImagePath = "~/Images/Hotel9.jpeg", Caption = "Deluxe Room", HotelId = 9 },
            new HotelImages { Id = 18, ImagePath = "~/Images/Hotel92.jpeg", Caption = "Restaurant", HotelId = 9 },
            new HotelImages { Id = 19, ImagePath = "~/Images/Hotel10.jpeg", Caption = "Deluxe Room", HotelId = 10 },
            new HotelImages { Id = 20, ImagePath = "~/Images/Hotel102.jpeg", Caption = "Restaurant", HotelId = 10 },
            new HotelImages { Id = 21, ImagePath = "~/Images/Hotel11.jpeg", Caption = "Deluxe Room", HotelId = 11 },
            new HotelImages { Id = 22, ImagePath = "~/Images/Hotel112.jpeg", Caption = "Restaurant", HotelId = 11 },
            new HotelImages { Id = 23, ImagePath = "~/Images/Hotel12.jpeg", Caption = "Deluxe Room", HotelId = 12 },
            new HotelImages { Id = 24, ImagePath = "~/Images/Hotel122.jpeg", Caption = "Restaurant", HotelId = 12 },
            new HotelImages { Id = 25, ImagePath = "~/Images/Hotel13.jpeg", Caption = "Deluxe Room", HotelId = 13 },
            new HotelImages { Id = 26, ImagePath = "~/Images/Hotel132.jpeg", Caption = "Restaurant", HotelId = 13 }

        );

            modelBuilder.Entity<RoomImages>().HasData(
            
            new RoomImages { Id = 1, RoomTypeId = 1, ImagePath = "~/Images/room10.jpeg", Caption = "Deluxe Room" },
            new RoomImages { Id = 2, RoomTypeId = 1, ImagePath = "~/Images/room12.jpeg", Caption = "Deluxe Room Bathroom" },
            
            new RoomImages { Id = 3, RoomTypeId = 2, ImagePath = "~/Images/room20.jpeg", Caption = "Super Deluxe Room" },
            new RoomImages { Id = 4, RoomTypeId = 2, ImagePath = "~/Images/room22.jpeg", Caption = "Super Deluxe Room View" },
            
            new RoomImages { Id = 5, RoomTypeId = 3, ImagePath = "~/Images/Hotel30.jpeg", Caption = "Executive Suite" },
            new RoomImages { Id = 6, RoomTypeId = 3, ImagePath = "~/Images/Hotel32.jpeg", Caption = "Executive Suite Living Area" },
            
            new RoomImages { Id = 7, RoomTypeId = 4, ImagePath = "~/Images/Hotel40.jpeg", Caption = "Presidential Suite" },
            new RoomImages { Id = 8, RoomTypeId = 4, ImagePath = "~/Images/Hotel42.jpeg", Caption = "Presidential Suite Bedroom" }
            
        );

            modelBuilder.Entity<HotelSingleImage>().HasData(
                new HotelSingleImage { Id = 1, ImagePath = "~/images/1.jpg", HotelId = 1 },
                new HotelSingleImage { Id = 2, ImagePath = "~/images/2.jpg", HotelId = 2 },
                new HotelSingleImage { Id = 3, ImagePath = "~/images/3.jpg", HotelId = 3 },
                new HotelSingleImage { Id = 4, ImagePath = "~/images/4.jpg", HotelId = 4 },
                new HotelSingleImage { Id = 5, ImagePath = "~/images/5.jpg", HotelId = 5 },
                new HotelSingleImage { Id = 6, ImagePath = "~/images/6.jpg", HotelId = 6 },
                new HotelSingleImage { Id = 7, ImagePath = "~/images/7.jpg", HotelId = 7 },
                new HotelSingleImage { Id = 8, ImagePath = "~/images/8.jpg", HotelId = 8 },
                new HotelSingleImage { Id = 9, ImagePath = "~/images/9.jpg", HotelId = 9 },
                new HotelSingleImage { Id = 10, ImagePath = "~/images/10.jpg", HotelId = 10 },
                new HotelSingleImage { Id = 11, ImagePath = "~/images/11.jpg",  HotelId = 11 },
                new HotelSingleImage { Id = 12, ImagePath = "~/images/12.jpg", HotelId = 12 },
                new HotelSingleImage { Id = 13, ImagePath = "~/images/13.jpg", HotelId = 13 }
            );

            modelBuilder.Entity<CityImage>().HasData(
                new CityImage { Id = 1, ImagePath = "~/images/new_delhi.jpg", CityId = 1 },
                new CityImage { Id = 2, ImagePath = "~/images/mumbai.jpg", CityId = 2 },
                new CityImage { Id = 3, ImagePath = "~/images/male.jpg", CityId = 3 },
                new CityImage { Id = 4, ImagePath = "~/images/bangkok.jpg", CityId = 4 },
                new CityImage { Id = 5, ImagePath = "~/images/beijing.jpg", CityId = 5 },
                new CityImage { Id = 6, ImagePath = "~/images/chennai.jpg", CityId = 6 },
                new CityImage { Id = 7, ImagePath = "~/images/kolkata.jpg", CityId = 7 },
                new CityImage { Id = 8, ImagePath = "~/images/colombo.jpg", CityId = 8 },
                new CityImage { Id = 9, ImagePath = "~/images/phuket.jpg", CityId = 9 },
                new CityImage { Id = 10, ImagePath = "~/images/shanghai.jpg", CityId = 10 }
            );

            //modelBuilder.Entity<BookingRoom>()
            //    .HasKey(br => new { br.BookingId, br.RoomId });

            //modelBuilder.Entity<BookingRoom>()
            //    .HasOne(br => br.Booking)
            //    .WithMany(b => b.BookingRooms)
            //    .HasForeignKey(br => br.BookingId);

            //modelBuilder.Entity<BookingRoom>()
            //    .HasOne(br => br.Room)
            //    .WithMany(r => r.BookingRooms)
            //    .HasForeignKey(br => br.RoomId);

            //modelBuilder.Entity<Hotel>()
            //.HasOne(h => h.Country)
            //.WithMany()
            //.HasForeignKey(h => h.CountryId)
            //.OnDelete(DeleteBehavior.NoAction);
        }
    }
}
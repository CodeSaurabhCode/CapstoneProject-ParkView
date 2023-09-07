using ParkViewServices.Data;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IHotelRepository Hotel { get; private set; }
        public IRoomRepository Room { get; private set; }
        public ICityRepository City { get; private set; }
        public IRoomTypesRepository RoomTypes { get; private set; }
        public IRoomCountRepository RoomCount { get; private set; }
        public IRoomImagesRepository RoomImages { get; private set; }
        public IHotelImagesRepository HotelImages { get; private set; }
        public IBookingRepository Booking { get; private set; }
        //public IBookingCartRoom bookingCartRooms { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IHotelSingleImageRepository HotelSingleImage { get; private set; }
        public ICityImageRepository CityImage { get; private set; }
        public IBookedListRepository BookedList { get; private set; }   
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Hotel = new HotelRepository(_db);
            Room = new RoomRepository(_db);
            City = new CityRepository(_db);
            RoomTypes = new RoomTypeRepository(_db);
            RoomCount = new RoomCountRepository(_db);
            RoomImages = new RoomImagesRespository(_db);  
            HotelImages = new HotelImagesRepository(_db);
            Booking = new BookingRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            HotelSingleImage = new HotelSingleImageRepository(_db);
            CityImage = new CityImageRepository(_db);
            BookedList = new BookedListRepository(_db);
            //bookingCartRooms = new BookCartRoomRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
       

        
    }
}

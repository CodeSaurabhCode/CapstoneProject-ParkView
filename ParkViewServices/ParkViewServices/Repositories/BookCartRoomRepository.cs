using ParkViewServices.Data;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class BookCartRoomRepository : GenericRepository<BookingCartRoom>, IBookingCartRoom
    {
        private readonly ApplicationDbContext _db;

        public BookCartRoomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BookingCartRoom obj)
        {
            _db.BookingCartRooms.Update(obj);
        }
    }
}

using ParkViewServices.Data;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly ApplicationDbContext _db;

        public BookingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Booking obj)
        {
            _db.Bookings.Update(obj);
        }
    }

}

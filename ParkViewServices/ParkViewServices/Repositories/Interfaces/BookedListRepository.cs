using ParkViewServices.Data;
using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;

namespace ParkViewServices.Repositories.Interfaces
{
    public class BookedListRepository : Repository<BookedList>, IBookedListRepository
    {
        private ApplicationDbContext _db;
        public BookedListRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(BookedList applicationUser)
        {
            _db.BookedList.Update(applicationUser);
        }
    }
}

using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IBookedListRepository : IRepository<BookedList>
    {
        public void Update(BookedList list);

    }
}

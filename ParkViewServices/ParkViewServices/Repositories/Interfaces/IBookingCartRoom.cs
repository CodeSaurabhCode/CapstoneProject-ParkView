using ParkViewServices.Models.Bookings;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IBookingCartRoom : IGenericRepository<BookingCartRoom>
    {
        void Update(BookingCartRoom obj);
    }
}

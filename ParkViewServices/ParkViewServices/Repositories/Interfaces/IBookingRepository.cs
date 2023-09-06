using ParkViewServices.Models.Bookings;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        void Update(Booking obj);
    }
}
    
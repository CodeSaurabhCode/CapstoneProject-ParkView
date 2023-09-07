using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Hotels;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IHotelSingleImageRepository : IGenericRepository<HotelSingleImage>
    {
        void Update(HotelSingleImage obj);
    }
}

using ParkViewServices.Models.Hotels;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        void Update(Hotel obj);
    }
}

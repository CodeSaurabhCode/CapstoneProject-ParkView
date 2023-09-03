using ParkViewServices.Models.Hotels;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IHotelImagesRepository : IGenericRepository<HotelImages>
    {
        void Update(HotelImages obj);
    }
}


using ParkViewServices.Models.Hotels;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface ICityImageRepository : IGenericRepository<CityImage>
    {
        void Update(CityImage obj);
    }
}

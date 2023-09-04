using ParkViewServices.Models.Hotels;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        void Update(City obj);
    }
}

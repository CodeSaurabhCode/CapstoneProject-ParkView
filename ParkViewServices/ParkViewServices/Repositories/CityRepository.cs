using ParkViewServices.Data;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(City obj)
        {
            _db.Cities.Update(obj);
        }
    }
    
}

using ParkViewServices.Data;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ParkViewServices.Repositories
{
    public class HotelRepository : GenericRepository<Hotel> , IHotelRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Hotel obj)
        {
            _db.Hotels.Update(obj);
        }
    }
}

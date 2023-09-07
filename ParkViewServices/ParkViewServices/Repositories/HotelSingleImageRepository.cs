using ParkViewServices.Data;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class HotelSingleImageRepository : GenericRepository<HotelSingleImage>, IHotelSingleImageRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelSingleImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(HotelSingleImage obj)
        {
            _db.HotelSingleImage.Update(obj);
        }
    }
}

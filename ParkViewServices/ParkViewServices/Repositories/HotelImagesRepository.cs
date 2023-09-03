using ParkViewServices.Data;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class HotelImagesRepository : GenericRepository<HotelImages>, IHotelImagesRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelImagesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(HotelImages obj)
        {
            _db.HotelImages.Update(obj);
        }
    }
    
}
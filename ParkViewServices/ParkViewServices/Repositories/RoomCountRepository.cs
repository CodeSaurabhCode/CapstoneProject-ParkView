using ParkViewServices.Data;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Models.Rooms;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class RoomCountRepository : GenericRepository<RoomCount>, IRoomCountRepository
    {
        private readonly ApplicationDbContext _db;

        public RoomCountRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(RoomCount obj)
        {
            _db.RoomCount.Update(obj);
        }
    }
 
}

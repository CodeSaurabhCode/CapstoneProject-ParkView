using ParkViewServices.Data;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Models.Rooms;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
       
        private readonly ApplicationDbContext _db;

        public RoomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Room obj)
        {
            _db.Rooms.Update(obj);
        }
       
    }
}

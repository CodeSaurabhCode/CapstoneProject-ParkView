using ParkViewServices.Data;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Models.Rooms;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class RoomTypeRepository : GenericRepository<RoomType>, IRoomTypesRepository
    {
        private readonly ApplicationDbContext _db;

        public RoomTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(RoomType obj)
        {
            _db.RoomTypes.Update(obj);
        }
    }
}

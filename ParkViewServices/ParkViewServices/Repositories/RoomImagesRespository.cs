using ParkViewServices.Data;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Models.Rooms;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class RoomImagesRespository : GenericRepository<RoomImages>, IRoomImagesRepository
    {
        private readonly ApplicationDbContext _db;

        public RoomImagesRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(RoomImages obj)
        {
            _db.RoomImages.Update(obj);
        }
    }
 
}

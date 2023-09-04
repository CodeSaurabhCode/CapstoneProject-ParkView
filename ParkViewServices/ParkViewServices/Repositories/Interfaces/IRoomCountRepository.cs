using ParkViewServices.Models.Rooms;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IRoomCountRepository : IGenericRepository<RoomCount>
    {
        void Update(RoomCount obj);
    }
}

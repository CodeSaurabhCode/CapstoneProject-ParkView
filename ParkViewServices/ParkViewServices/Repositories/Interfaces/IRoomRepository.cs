using ParkViewServices.Models.Rooms;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        void Update(Room obj);
    }
}

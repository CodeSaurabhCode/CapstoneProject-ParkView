using ParkViewServices.Models.Rooms;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IRoomTypesRepository : IGenericRepository<RoomType>
    {
        void Update(RoomType obj);
    }
}

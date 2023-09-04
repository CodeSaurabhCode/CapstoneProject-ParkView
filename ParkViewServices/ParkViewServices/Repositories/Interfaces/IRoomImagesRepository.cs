using ParkViewServices.Models.Rooms;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IRoomImagesRepository : IGenericRepository<RoomImages>
    {
        void Update(RoomImages obj);
    }
}

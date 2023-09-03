namespace ParkViewServices.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IHotelRepository Hotel { get; }
        IRoomRepository Room { get; }

        void Save();
    }
}

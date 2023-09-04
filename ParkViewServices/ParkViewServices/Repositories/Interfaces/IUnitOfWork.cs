namespace ParkViewServices.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IHotelRepository Hotel { get; }
        IRoomRepository Room { get; }
        ICityRepository City { get; }


        void Save();
    }
}

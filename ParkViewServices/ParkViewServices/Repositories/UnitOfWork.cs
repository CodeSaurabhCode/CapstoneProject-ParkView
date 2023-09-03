using ParkViewServices.Data;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IHotelRepository Hotel { get; private set; }
        public IRoomRepository Room { get; private set; }
        public ICityRepository City { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Hotel = new HotelRepository(_db);
            Room = new RoomRepository(_db);
            //City = new CityR(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
       

        
    }
}

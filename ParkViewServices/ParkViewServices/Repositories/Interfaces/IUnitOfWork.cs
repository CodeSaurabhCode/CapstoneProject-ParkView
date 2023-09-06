namespace ParkViewServices.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IHotelRepository Hotel { get; }
        IRoomRepository Room { get; }
        ICityRepository City { get; }
        IHotelImagesRepository HotelImages { get; }
        IRoomCountRepository RoomCount { get; }
        IRoomImagesRepository RoomImages { get; }
        IRoomTypesRepository RoomTypes { get; }
        IBookingRepository Booking { get; }
        //IBookingCartRoom BookingCartRoom { get; }
        IApplicationUserRepository ApplicationUser { get; }

        void Save();
    }
}

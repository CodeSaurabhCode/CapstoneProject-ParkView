using ParkViewServices.Models.Rooms;

namespace ParkViewServices.Models.Bookings
{
    public class BookingCartRoom : BaseEntity
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public string BookingCartId { get; set; }
        public int Quantity { get; set; }

    }
}

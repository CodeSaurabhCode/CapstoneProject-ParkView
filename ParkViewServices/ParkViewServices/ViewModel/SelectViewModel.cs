using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Rooms;

namespace ParkViewServices.ViewModel
{
    public class SelectViewModel
    {
        public Booking booking { get; set; }
        public IEnumerable<RoomCount> roomCounts { get; set; }
        public int HotelId { get; set; }
        public IEnumerable<Room> bookedRooms { get; set; }
    }
}

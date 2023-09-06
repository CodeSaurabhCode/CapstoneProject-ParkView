
using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Hotels;

namespace ParkViewServices.Models.Rooms
{
    public class Room : BaseEntity
    {
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int BedCount { get; set; }
        //public int Price { get; set; }
        public bool Status { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        //public ICollection<BookingRoom> BookingRooms { get; set; }
    }
}

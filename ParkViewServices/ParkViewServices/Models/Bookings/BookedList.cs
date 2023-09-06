using ParkViewServices.Models.Rooms;

namespace ParkViewServices.Models.Bookings
{
    public class BookedList 
    {
        public Guid Id { get; set; }
        public List<Room> bookedRooms = new List<Room>();  
    }
}

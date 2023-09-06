using ParkViewServices.Models.Hotels;
using System.ComponentModel.DataAnnotations;

namespace ParkViewServices.Models.Rooms
{
    public class RoomCount : BaseEntity
    {
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
        public int RoomTypeID { get; set; } 
        public RoomType RoomType { get; set; }
        public int Count { get; set; }
        public int Occupied { get; set; }

    }
}

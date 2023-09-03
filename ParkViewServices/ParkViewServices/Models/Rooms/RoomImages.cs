namespace ParkViewServices.Models.Rooms
{
    public class RoomImages : BaseEntity
    {
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
    }
}

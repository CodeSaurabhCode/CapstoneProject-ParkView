namespace ParkViewServices.Models.Rooms
{
    public class RoomType : BaseEntity
    {
        public string RoomTypeName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}

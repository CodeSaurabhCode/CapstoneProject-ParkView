namespace ParkViewServices.Models.Hotels
{
    public class HotelImages : BaseEntity
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
    }
}

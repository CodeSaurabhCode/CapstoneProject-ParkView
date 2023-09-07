namespace ParkViewServices.Models.Hotels
{
    public class HotelSingleImage : BaseEntity
    {
        public string ImagePath { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}

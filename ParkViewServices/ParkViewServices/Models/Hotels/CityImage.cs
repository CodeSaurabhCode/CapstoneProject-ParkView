namespace ParkViewServices.Models.Hotels
{
    public class CityImage : BaseEntity
    {
        public string ImagePath { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}

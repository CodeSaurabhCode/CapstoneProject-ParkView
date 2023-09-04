namespace ParkViewServices.Models.Hotels
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int TotalRooms { get; set; }
        //public int CountryId { get; set; }
        //public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
       
    }
}

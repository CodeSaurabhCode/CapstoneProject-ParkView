using ParkViewServices.Models.Hotels;

namespace ParkViewServices.ViewModel
{
    public class CityHotelsViewModel
    { 
        public City ViewCity { get; set; }
        public IEnumerable<Hotel> ViewHotels { get; set; } 
        public IEnumerable<City> ViewCities { get; set; }
        public IEnumerable<HotelSingleImage> ViewHotelImages { get; set;}
    }
}

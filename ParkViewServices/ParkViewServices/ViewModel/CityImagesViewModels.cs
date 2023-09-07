using ParkViewServices.Models.Hotels;

namespace ParkViewServices.ViewModel
{
    public class CityImagesViewModels
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<CityImage> Images { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using ParkViewServices.Repositories.Interfaces;
using ParkViewServices.ViewModel;

namespace ParkViewServices.Controllers
{
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("[Controller]")]
        [Route("[Controller]/{int id}")]
        public IActionResult Index(int id)
        {
            if(id != 0)
            {
                var city = _unitOfWork.City.Get(u => u.Id == id);
                var hotels = _unitOfWork.Hotel.GetAll(h => h.CityId == city.Id, includeProperties: "City");

                CityHotelsViewModel cityHotelsViewModel = new CityHotelsViewModel()
                {
                    ViewCity = city,
                    ViewHotels = hotels
                };

                return View(cityHotelsViewModel);

            }
            
            var cities = _unitOfWork.City.GetAll(includeProperties: "Country");

            CityHotelsViewModel cityHotelsViewModel1 = new CityHotelsViewModel() { ViewCities = cities };
            return View(cityHotelsViewModel1);
            

            
        }
    }
}

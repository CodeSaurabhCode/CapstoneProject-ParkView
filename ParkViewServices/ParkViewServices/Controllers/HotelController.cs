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
            var hotel = _unitOfWork.Hotel.Get(u => u.Id == id, includeProperties:"City");
            //var hotels = _unitOfWork.Hotel.GetAll(h => h.CityId == city.Id, includeProperties: "City");
            return View(hotel);
        }
    }
}

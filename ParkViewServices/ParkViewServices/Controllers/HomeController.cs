using Microsoft.AspNetCore.Mvc;
using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Rooms;
using ParkViewServices.Repositories.Interfaces;
using ParkViewServices.ViewModel;
using System.Diagnostics;

namespace ParkViewServices.Controllers
{
    public class HomeController : Controller
    { 
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        { 
            var bookings = _unitOfWork.Booking.GetAll(u => u.CheckOutDate.Date == DateTime.UtcNow.Date );
    

            return View();
        }

        public IActionResult Explore()
        {
            var hotels = _unitOfWork.Hotel.GetAll(includeProperties: "City");
            var cities = _unitOfWork.City.GetAll();
            var images = _unitOfWork.HotelSingleImage.GetAll();

            CityHotelsViewModel cityHotels = new CityHotelsViewModel() 
            { 
                ViewCities = cities,
                ViewHotels = hotels,
                ViewHotelImages = images
            };
            return View(cityHotels);
        }

        public IActionResult Privacy(int id)
        {
            var hotel = _unitOfWork.Hotel.Get(u => u.Id == id, includeProperties: "City");
            return View(hotel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
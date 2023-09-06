using Microsoft.AspNetCore.Mvc;
using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Repositories.Interfaces;
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
            Booking booking = new Booking();    
            var hotels = _unitOfWork.Hotel.GetAll(includeProperties : "City");
            var cities = _unitOfWork.City.GetAll();
            return View(booking);
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
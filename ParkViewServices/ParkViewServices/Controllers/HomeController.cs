using Microsoft.AspNetCore.Mvc;
using ParkViewServices.Models;
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
            var hotels = _unitOfWork.Hotel.GetAll(includeProperties : "City");
            return View(hotels);
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

        public IActionResult Explore()
        {
            return View();
        }

    }
}
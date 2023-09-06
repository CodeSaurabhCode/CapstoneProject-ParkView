using Microsoft.AspNetCore.Mvc;

namespace ParkViewServices.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

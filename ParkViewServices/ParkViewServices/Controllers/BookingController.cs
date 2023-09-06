using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ParkViewServices.Helpers;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Rooms;
using ParkViewServices.Repositories.Interfaces;
using ParkViewServices.ViewModel;

namespace ParkViewServices.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookingCart _bookingCart;

        public BookingController(IUnitOfWork unitOfWork, BookingCart bookingCart)
        {
            _unitOfWork = unitOfWork;
            _bookingCart = bookingCart;
        }

        [Route("[Controller]")]
        public IActionResult Index()
        {
            var cities = _unitOfWork.City.GetAll(includeProperties:"Country");
            return View(cities);
        }

        [HttpGet]
        [Route("[Controller]/[action]")]
        public IActionResult Book(int cityId)
        {
            var hotels = _unitOfWork.Hotel.GetAll(u=> u.CityId == cityId, includeProperties:"City");
            var viewModel = new BookingViewModel
            {
                Hotels = new SelectList(hotels, "Id", "Name"),
            };
            HttpContext.Session.SetObject("CityId", cityId);


            return View(viewModel);
        }

        [HttpPost]
        [Route("[Controller]/[action]")]
        public IActionResult Book(BookingViewModel viewModel, int cityId)
        {

            if (!ModelState.IsValid && ModelState.ContainsKey("HotelId"))
            {
                
                ModelState.Remove("Hotels");
               
            }

            if (ModelState.IsValid)
            {
                Booking booking = new Booking()
                {
                    CheckInDate = viewModel.CheckInDate,
                    CheckOutDate = viewModel.CheckOutDate,
                    UserEmail = viewModel.UserEmail,
                    NumberOfAdults = viewModel.NumberOfGuests,
                    NumberOfRooms = viewModel.NumberOfRooms,
                    TotalAmount = 0
                };
                //var bookingJson = JsonConvert.SerializeObject(booking);
                //TempData["Booking"] = booking;

                HttpContext.Session.SetObject("bookings", booking);

                return RedirectToAction("SelectRooms", new {HotelId = viewModel.HotelId });
            }

            cityId = HttpContext.Session.GetObject<int>("CityId");
            var hotels = _unitOfWork.Hotel.GetAll(u => u.CityId == cityId, includeProperties: "City");
            viewModel.Hotels = new SelectList(hotels, "Id", "Name");

            return View(viewModel);

        }

        public IActionResult SelectRooms(int BookingId, int HotelId)
        {
            var availableRoomCount = _unitOfWork.RoomCount.GetAll(u => u.HotelID == HotelId, includeProperties: "Hotel,RoomType");
            var bookings = HttpContext.Session.GetObject<Booking>("bookings");

            var items = _bookingCart.GetBookingCartRooms();
            if (items != null)
            {
                List<Room> itemsIncludingRoomType = new List<Room>();
                foreach (var item in items)
                {
                    itemsIncludingRoomType.Add(_unitOfWork.Room.Get(u => u.Id == item.Room.Id, includeProperties: "RoomType"));
                }
                if (itemsIncludingRoomType.Count == bookings.NumberOfRooms)
                {
                    var GuidId = Guid.NewGuid();
                    bookings.BookedListId = GuidId;
                    bookings.BookedList = new BookedList()
                    {
                        Id = GuidId,
                        bookedRooms = itemsIncludingRoomType
                    };
                    HttpContext.Session.SetObject("bookings", bookings);
                    _unitOfWork.Booking.Add(bookings);
                    _unitOfWork.Save();
                }
                SelectViewModel selectView1 = new SelectViewModel()
                {
                    booking = bookings,
                    roomCounts = availableRoomCount,
                    HotelId = HotelId,
                    bookedRooms = itemsIncludingRoomType
                };

                return View(selectView1);

            }
            SelectViewModel selectView = new SelectViewModel()
            {
                booking = bookings,
                roomCounts = availableRoomCount,
                HotelId = HotelId,
            };
            return View(selectView);
        }

        

        [HttpPost]
        public IActionResult SelectRooms(SelectViewModel addRooms , int BookingId, int HotelId)
        {
            var items = _bookingCart.GetBookingCartRooms();
            if (items != null)
            {
                List<Room> itemsIncludingRoomType = new List<Room>();
                foreach (var item in items)
                {
                    itemsIncludingRoomType.Add(_unitOfWork.Room.Get(u => u.Id == item.Room.Id, includeProperties: "RoomType"));
                }

            }

            return View();
        }


        private decimal CalculateTotalAmount(Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            var duration = (checkOutDate - checkInDate).Days;
            var roomRate = 100; 
            return duration * roomRate;
        }

        [Route("[Controller]/[action]")]
        public IActionResult Confirmation(int id)
        {
            return View(id);
        }

    }
}


        
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ParkViewServices.Helpers;
using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Hotels;
using ParkViewServices.Models.Rooms;
using ParkViewServices.Repositories.Interfaces;
using ParkViewServices.ViewModel;
using Razorpay.Api;
using System.Security.Claims;

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
            var images = _unitOfWork.CityImage.GetAll(includeProperties: "City");
            CityImagesViewModels viewModels = new CityImagesViewModels() 
            { 
                Cities = cities,
                Images = images
            };
            return View(viewModels);
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
                HttpContext.Session.SetObject("HotelId", viewModel.HotelId);

            }

            if (ModelState.IsValid)
            {
                Booking booking = new Booking()
                {
                    CheckInDate = viewModel.CheckInDate,
                    CheckOutDate = viewModel.CheckOutDate,
                    NumberOfAdults = viewModel.NumberOfGuests,
                    NumberOfChildren7To12 = viewModel.NumberOfChildren7to12,
                    NumberOfRooms = viewModel.NumberOfRooms,
                    TotalAmount = 0
                };
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
                    Room room = _unitOfWork.Room.Get(u => u.Id == item.Room.Id, includeProperties: "RoomType");
                    itemsIncludingRoomType.Add(room);
                    //room.Status = true;
                    //RoomCount specificRoomCount = _unitOfWork.RoomCount.Get(u => u.RoomTypeID == room.RoomTypeId && u.HotelID == HotelId);
                    //specificRoomCount.Occupied += 1;
                    //_unitOfWork.Room.Update(room);
                    //_unitOfWork.RoomCount.Update(specificRoomCount);
                    //_unitOfWork.Save();
                }
                if (itemsIncludingRoomType.Count == bookings.NumberOfRooms)
                {
                    var totalAmount = CalculateTotalAmount(itemsIncludingRoomType, bookings.CheckInDate, bookings.CheckOutDate);
                    bookings.TotalAmount = totalAmount;
                    var GuidId = Guid.NewGuid();
                    bookings.BookedListId = GuidId;
                    bookings.BookedList = new BookedList()
                    {
                        Id = GuidId,
                        bookedRooms = itemsIncludingRoomType
                    };
                    HttpContext.Session.SetObject("bookings", bookings);
                    //_unitOfWork.Booking.Add(bookings);
                    //_unitOfWork.Save();
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


        private decimal CalculateTotalAmount(List<Room> room, DateTime checkInDate, DateTime checkOutDate)
        {
            var nights = DateCalculator.CalculateNightsBetweenDates(checkInDate, checkOutDate);
            var totalAmount = 0;
            foreach (var item in room)
            {
                totalAmount += item.RoomType.Price * nights;
            };
            return totalAmount;
        }


        [Authorize]
        [Route("[Controller]/[action]")]    
        public async Task<IActionResult> Confirmation()
        {
            var HotelId = HttpContext.Session.GetObject<int>("HotelId");
            var hotel = _unitOfWork.Hotel.Get(u=> u.Id == HotelId, includeProperties:"City");
            var bookings = HttpContext.Session.GetObject<Booking>("bookings");
            var totalnights = DateCalculator.CalculateNightsBetweenDates(bookings.CheckInDate, bookings.CheckOutDate);

            
            
            ReviewBookingViewModel viewModel = new ReviewBookingViewModel()
            {
                Hotel = hotel,
                Booking = bookings,
                TotalNights = totalnights,
               
            };
            return View(viewModel);
        }
        [Authorize]
        public IActionResult InitiateBooking()
        {
            string key = "rzp_test_EGeKE9UnAG7Tu1";
            string secret = "ngybUA0RNRSGJZSxZnEVAyNJ";

            Random _random = new Random();
            string transactionId = _random.Next(0, 10000).ToString();

            var bookings = HttpContext.Session.GetObject<Booking>("bookings");

            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
            bookings.UserEmail = user.Email;
            HttpContext.Session.SetObject("bookings", bookings);
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", Convert.ToDecimal(bookings.TotalAmount)*100); 
            input.Add("currency", "INR");
            input.Add("receipt", transactionId);


            RazorpayClient client = new RazorpayClient(key, secret);

            Razorpay.Api.Order order = client.Order.Create(input);
            var orderId = order["id"].ToString();

            PaymentViewModel viewModel = new PaymentViewModel() 
            { 
                bookings = bookings,
                User = user,
                OrderId = orderId
            };

            return View("Payment", viewModel);
        }

        public IActionResult Payment(string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razorpay_payment_id", razorpay_payment_id);
            attributes.Add("razorpay_order_id", razorpay_order_id);
            attributes.Add("razorpay_signature", razorpay_signature);

            Utils.verifyPaymentSignature(attributes);
            var bookings = HttpContext.Session.GetObject<Booking>("bookings");

            bookings.PaymentStatus = true;
            bookings.TransactionId = razorpay_payment_id;

            _unitOfWork.Booking.Add(bookings);
            _unitOfWork.Save();
            return View("PaymentSuccess", bookings);
        }

    }
}


        
using Microsoft.AspNetCore.Mvc;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Rooms;
using ParkViewServices.Repositories.Interfaces;

namespace ParkViewServices.Controllers
{
    public class BookingCartController : Controller
    {
        private readonly BookingCart _bookingCart;
        private readonly IUnitOfWork _unitOfWork;

        public BookingCartController(BookingCart bookingCart, IUnitOfWork unitOfWork)
        {
            _bookingCart = bookingCart;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var items = _bookingCart.GetBookingCartRooms();
            List<Room> itemsIncludingRoomType = new List<Room>();
            foreach (var item in items)
            {
                itemsIncludingRoomType.Add( _unitOfWork.Room.Get(u => u.Id == item.Room.Id, includeProperties: "RoomType"));
            }
            return View(itemsIncludingRoomType);
        }

        [Route("[Controller]/[action]/{RoomTypeId:int}/{HotelId:int}")]
        public IActionResult AddToCart(int RoomTypeId, int HotelId)
        {
            var selectedRoom = _unitOfWork.Room.GetAll(u => u.HotelId == HotelId && u.RoomTypeId == RoomTypeId && u.Status == false, includeProperties: "RoomType").FirstOrDefault();
            if (selectedRoom != null)
            {
                _bookingCart.AddToCart(selectedRoom);
            }
            //return RedirectToAction("Index");
            return RedirectToAction("SelectRooms", "Booking", new {HotelId = HotelId});

        }

        public IActionResult RemoveFromCart(int RoomTypeId, int HotelId)
        {
            var selectedRoom = _unitOfWork.Room.GetAll(u => u.HotelId == HotelId && u.RoomTypeId == RoomTypeId && u.Status == false, includeProperties: "RoomType").FirstOrDefault();
            if (selectedRoom != null)
            {
                _bookingCart.RemoveItemFromCart(selectedRoom.Id);
            }
            //return RedirectToAction("Index");
            return RedirectToAction("SelectRooms", "Booking", new { HotelId = HotelId });

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkViewServices.Helpers;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Rooms;
using ParkViewServices.Repositories.Interfaces;
using Razorpay.Api;

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
            //var booking = HttpContext.Session.GetObject<Booking>("bookings");

            //var bookedRooms = _unitOfWork.BookedList.GetAll();

            //if (bookedRooms.Any())
            //{
            //    foreach (var bookedroom in bookedRooms)
            //    { 
                    
            //        var booking = _unitOfWork.Booking.Get(x => x.BookedListId == bookedroom.Id);

            //        foreach (var item in bookedroom.bookedRooms)
            //        {
                        
            //            Room room = _unitOfWork.Room.Get(x => x.Id == item.Id);
            //        }

            //        if (booking != null)
            //        {
            //            if ((booking.CheckOutDate >= form.check_in && booking.CheckInDate <= form.check_in) || (booking.CheckInDate <= form.check_out && booking.CheckOutDate >= form.check_out))
            //            {
            //                rooms.Remove(room);
            //            }
            //        }
            //    }




                var selectedRoom = _unitOfWork.Room.GetAll(u => u.HotelId == HotelId && u.RoomTypeId == RoomTypeId && u.Status == false, includeProperties: "RoomType").FirstOrDefault();
            if (selectedRoom != null)
            {
                _bookingCart.AddToCart(selectedRoom);
                selectedRoom.Status = true;
                var roomcount = _unitOfWork.RoomCount.Get(u => u.RoomTypeID == selectedRoom.RoomTypeId && u.HotelID == HotelId);
                roomcount.Occupied += 1;
                _unitOfWork.Room.Update(selectedRoom);
                _unitOfWork.RoomCount.Update(roomcount);
                _unitOfWork.Save();
            }
            //return RedirectToAction("Index");
            return RedirectToAction("SelectRooms", "Booking", new {HotelId = HotelId});

        }

        public IActionResult RemoveFromCart(int RoomId, int HotelId)
        {
            var selectedRoom = _unitOfWork.Room.GetAll(u => u.HotelId == HotelId && u.Id == RoomId, includeProperties: "RoomType").FirstOrDefault();
            if (selectedRoom != null)
            {
                _bookingCart.RemoveItemFromCart(selectedRoom.Id);
                selectedRoom.Status = false;
                var roomcount = _unitOfWork.RoomCount.Get(u => u.RoomTypeID == selectedRoom.RoomTypeId && u.HotelID == HotelId);
                roomcount.Occupied -= 1;
                _unitOfWork.Room.Update(selectedRoom);
                _unitOfWork.RoomCount.Update(roomcount);
                _unitOfWork.Save();
            }
            //return RedirectToAction("Index");
            return RedirectToAction("SelectRooms", "Booking", new { HotelId = HotelId });

        }

        
    }
}

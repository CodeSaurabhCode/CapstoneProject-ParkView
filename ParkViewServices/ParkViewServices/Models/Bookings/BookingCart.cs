using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;
using ParkViewServices.Data;
using ParkViewServices.Models.Rooms;

namespace ParkViewServices.Models.Bookings
{
    public class BookingCart
    {
        public string Id { get; set; }
        public List<BookingCartRoom> Items { get; set; }
        public decimal total { get; set; }
        private readonly ApplicationDbContext _context;

        public BookingCart(ApplicationDbContext context)
        {
            _context = context;
        }


        public static BookingCart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            var context = serviceProvider.GetService<ApplicationDbContext>();
            string cartid = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartid);
            return new BookingCart(context) { Id = cartid };
        }

        public void AddToCart(Room room)
        {
            var shoppingCartItem = _context.BookingCartRooms.SingleOrDefault(i => i.Room.Id == room.Id && i.BookingCartId == Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new BookingCartRoom
                {
                    Room = room,
                    BookingCartId = Id,
                    Quantity = 1
                };
                _context.BookingCartRooms.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public List<BookingCartRoom> GetBookingCartRooms()
        {
            return Items ?? (
                Items = _context.BookingCartRooms.Where(c => c.BookingCartId == Id).Include(s => s.Room).ToList()
                );
        }

        public decimal GetBookingCartTotal()
        {
            var total = _context.BookingCartRooms.Where(c => c.BookingCartId == Id).Select(c => c.Room.RoomType.Price * c.Quantity).Sum();
            return total;
        }

        public void RemoveItemFromCart(int itemid)
        {
            var shoppingCartItem = _context.BookingCartRooms.OrderBy(c=> c.Id).Last(c => c.Room.Id == itemid);
            _context.BookingCartRooms.Remove(shoppingCartItem);
            _context.SaveChanges();
        }
    }
}

using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;

namespace ParkViewServices.ViewModel
{
    public class PaymentViewModel
    {
        public Booking bookings { get; set; }

        public ApplicationUser User { get; set; } 
        public string OrderId { get; set; }
    }
}

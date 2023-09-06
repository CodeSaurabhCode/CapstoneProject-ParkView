using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Models.Hotels;

namespace ParkViewServices.ViewModel
{
    public class ReviewBookingViewModel
    {
        public Hotel Hotel { get; set; }
        public Booking Booking { get; set; }
        public decimal? TotalAmount { get; set; } 
        public int TotalNights { get; set; }  
        
        public ApplicationUser? User { get; set; }
    }
}

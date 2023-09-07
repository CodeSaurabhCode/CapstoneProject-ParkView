using ParkViewServices.Helpers;
using ParkViewServices.Models.Hotels;
using System.ComponentModel.DataAnnotations;

namespace ParkViewServices.Models.Bookings
{
    public class Booking : BaseEntity   
    {
        public string UserEmail { get; set; }
        //public int HotelId { get; set; }    
        //public Hotel Hotel { get; set; }

        [Required(ErrorMessage = "Check-in date is required.")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-out date is required.")]
        [DataType(DataType.Date)]
        [DateGreaterThan("CheckInDate", ErrorMessage = "Check-out date must be greater than check-in date.")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "Number of adults is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of adults must be greater than 0.")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Number of adults is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of adults must be greater than 0.")]
        public int NumberOfAdults { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number of children cannot be negative.")]
        public int? NumberOfChildrenBelow7 { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number of children cannot be negative.")]
        public int? NumberOfChildren7To12 { get; set; }

        [Required(ErrorMessage = "Total amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0.")]
        public decimal TotalAmount { get; set; }
            
        public bool? PaymentStatus { get; set; }
        public string? TransactionId { get; set; }

        public bool? IsConfirmed { get; set; }
        public bool? IsCancelled { get; set; }
        public DateTime? CancellationDate { get; set; }
                 
        public string? PromoCode { get; set; }              
        public DateTime? BookingDate { get; set; }      
        //public ICollection<BookingRoom> BookingRooms { get; set; }
        public Guid? BookedListId { get; set; }
        public BookedList? BookedList { get; set; }
    }
}

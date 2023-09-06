using ParkViewServices.Models.Rooms;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ParkViewServices.ViewModel
{
    public class BookingWithRoomsList
    {

        [Required(ErrorMessage = "Please select a hotel.")]
        [Display(Name = "Select Hotel")]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email Address")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please select the check-in date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Check-In Date")]
        public DateTime CheckInDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please select the check-out date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Check-Out Date")]
        public DateTime CheckOutDate { get; set; } = DateTime.Now.AddDays(1);

        [Range(1, int.MaxValue, ErrorMessage = "Please select the number of rooms.")]
        [Display(Name = "Number of Rooms")]
        public int NumberOfRooms { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select the number of guests.")]
        [Display(Name = "Number of Guests")]
        public int NumberOfGuests { get; set; }

        public IEnumerable<Room> BookedRooms { get; set; }
    }
}

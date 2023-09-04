using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParkViewServices.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage ="Your name is required to proceed")]
        public string Name {get; set;}

        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set;}

        [DataType(DataType.EmailAddress)] 
        public string EmailAddress { get; set;}   

        public string Address { get; set;}

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set;}

    }
}

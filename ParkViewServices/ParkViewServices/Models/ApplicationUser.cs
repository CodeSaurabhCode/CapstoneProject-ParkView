using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParkViewServices.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage ="Your name is required to proceed")]
        public string Name {get; set;}

        public string? StreetAddress { get; set;}
        public string? City { get; set;}
        public string? State { get; set;}
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set;}

    }
}

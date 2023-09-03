using System.ComponentModel.DataAnnotations;

namespace ParkViewServices.Models
{
    public class BaseEntity
    {
        [Key] public int Id { get; set; }
    }
}

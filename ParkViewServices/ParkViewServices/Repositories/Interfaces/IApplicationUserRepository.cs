using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;

namespace ParkViewServices.Repositories.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        public void Update(ApplicationUser applicationUser);
    }
}
    
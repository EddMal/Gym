using Microsoft.AspNetCore.Identity;

namespace Gym.Web.Models
{
    public class ApplicationUser: IdentityUser
    {
        //Nav prop
        public ICollection<ApplicationUserGymClass> AttendingClasses { get; set; }
    }
}

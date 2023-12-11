using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models
{
    public class ApplicationUserGymClass
    {
        //Add attributes, input validation.
        //Foreign keys
        [MaxLength(450)]
        public string ApplicationUserId { get; set; } = default!;
        public Guid GymClassId { get; set; } 

        //Navigation Properties

        public ApplicationUser applicationUser { get; set; } = default!;
        public GymClass gymClass { get; set; } = default!;
    }
}

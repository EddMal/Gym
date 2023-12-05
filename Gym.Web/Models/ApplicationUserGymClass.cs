namespace Gym.Web.Models
{
    public class ApplicationUserGymClass
    {
        //Foreign keys
        public int ApplicationUserId { get; set; }
        public int GymClassId { get; set; }

        //Navigation Properties?

        //public ApplicationUser applicationUser { get; set; }
        //public GymClass gymClass { get; set;}
    }
}

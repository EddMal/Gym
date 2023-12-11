using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models
{
    public class GymClass
    {
        //Add attributes, input validation.
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        //[Range(typeof(TimeSpan),"00:05:00","24:00:")]
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } }
        public string Description { get; set; }

        //Nav prop
        public ICollection<ApplicationUserGymClass>? AttendingMembers { get; set; }

    }
}

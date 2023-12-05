namespace Gym.Web.Models
{
    public class GymClass
    {

        int Id { get; set; }
        string Name { get; set; }
        DateTime StartTime { get; set; }
        TimeSpan Duration { get; set; }
        DateTime EndTime { get { return StartTime + Duration; } }
        string Description { get; set; }

    }
}

﻿using Microsoft.AspNetCore.Identity;

namespace Gym.Web.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        //Nav prop
        public ICollection<ApplicationUserGymClass>? AttendingClasses { get; set; }
    }
}

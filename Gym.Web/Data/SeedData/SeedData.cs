using Gym.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Gym.Web.Data.SeedData
{
    public class SeedData
    {
        private static ApplicationDbContext context = default!;
        private static RoleManager<IdentityRole> roleManager = default!;
        private static UserManager<ApplicationUser> userManager = default!;


        public static async Task Init(ApplicationDbContext _context, IServiceProvider services)
        {
            context = _context;

            if (context.Roles.Any()) return;

            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            var roleNames = new[] { "User", "Admin" };
            var adminEmail = (string v) => { return $"admin{v}@admin.com"; };
            var userEmail = (string v) => { return $"user{v}@user.com"; };
            var adminPassword = (string v) => { return $"Admin{v}@admin.com"; };
            var userPassword = (string v) => { return $"User{v}@user.com"; };

            await AddRolesAsync(roleNames);

            var admin = await AddAccountAsync(adminEmail, "Admin", "Admin", 0, adminPassword, "2");
            var user = await AddAccountAsync(userEmail, "User", "User", 0, userPassword, "2");

            await AddminUserToRoleAsync(admin, "Admin");
            await AddminUserToRoleAsync(user, "User");
        }


        private static async Task AddRolesAsync(string[] roleNames)
        {
            foreach(var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }

        private static async Task<ApplicationUser> AddAccountAsync(Func<string, string> email, string firstName, string lastName, int age, Func<string, string> password, string mailPasswordExtension)
        {
            var found = await userManager.FindByEmailAsync(email(mailPasswordExtension));
            
            if (found != null) return null!;

            //if(age == 0)
            //{
            //    Random pseudoRandomAge = new Random();
            //    age = pseudoRandomAge.Next(17, 125);
            //}


            var user = new ApplicationUser
            {
                UserName = email(mailPasswordExtension),
                Email = email(mailPasswordExtension),
                FirstName = $"{firstName}{mailPasswordExtension}",
                LastName = $"{lastName}{mailPasswordExtension}",
                //Age = age,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(user,password(mailPasswordExtension));
            
            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

            return user;
        }
        private static async Task AddminUserToRoleAsync(ApplicationUser user, string roleName)
        {
            if (!await userManager.IsInRoleAsync(user, roleName))
            {

                var result = await userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
                context.Entry(user).Property("TimeOfRegistration").CurrentValue = DateTime.Now;
            }
        }



    }

}

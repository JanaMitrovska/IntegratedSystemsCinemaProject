using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace App.Areas.Identity.Data
{
    public class DatabaseInitializer
    {

        private static readonly string standardUser = "standard";
        private static readonly string adminUser = "admin";
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<AppIdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.UserName = "admin@mail.com";
                user.Email = "admin@mail.com";
                user.BirthDate = DateTime.Now.Date;
                string password = "Pa$$w0rd";

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, adminUser).Wait();
                }
            }

            if (userManager.FindByNameAsync("user1@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "John";
                user.LastName = "Smith";
                user.UserName = "user1@mail.com";
                user.Email = "user1@mail.com";
                user.BirthDate = new DateTime(1989, 1, 1);
                string password = "Pa$$w0rd";

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, standardUser).Wait();
                }
            }

            if (userManager.FindByNameAsync("user2@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Dave";
                user.LastName = "Norton";
                user.UserName = "user2@mail.com";
                user.Email = "user2@mail.com";
                user.BirthDate = new DateTime(1968, 10, 7);
                string password = "Pa$$w0rd";

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, standardUser).Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<AppIdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(standardUser).Result)
            {
                AppIdentityRole role = new AppIdentityRole();
                role.Name = standardUser;
                role.Description = "Performs standard user operations";

                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(adminUser).Result)
            {
                AppIdentityRole role = new AppIdentityRole();
                role.Name = adminUser;
                role.Description = "Performs all the operations";

                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}

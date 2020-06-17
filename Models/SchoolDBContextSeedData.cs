using System;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolManagementAPI.Models
{ 
    public static class SchoolDBContextSeedData
    {

        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<SchoolDBContext>();

            string[] roles = { "Owner", "Administrator", "Manager", "Editor", "Buyer", "Business", "Seller", "Subscriber" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    _ = await roleStore.CreateAsync(new IdentityRole(role));
                }
            }


            var user = new AppUser
            {
                //FirstName = "XXXX",
                //LastName = "XXXX",
                Email = "xxxx@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "Owner",
                NormalizedUserName = "OWNER",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "secret");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(context);
                var result = await userStore.CreateAsync(user);

            }

            _ = AssignRoles(serviceProvider, user.Email, roles);

            _ = context.SaveChangesAsync();
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<AppUser> _userManager = services.GetService<UserManager<AppUser>>();
            AppUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }
        //    private SchoolDBContext _schoolDBContext;

        //    public SchoolDBContextSeedData(SchoolDBContext schoolDBContext)
        //    {
        //        _schoolDBContext = schoolDBContext;
        //    }        

        //    public async Task SeedData()
        //    {
        //        await SeedRoles();
        //        await SeedAdmin();
        //        await _schoolDBContext.SaveChangesAsync();
        //    }

        //    public async Task SeedRoles()
        //    {
        //        string[] roles = { "Administrator", "Staff", "Parent", "Student"};

        //        foreach (string role in roles)
        //        {
        //            var roleStore = new RoleStore<IdentityRole>(_schoolDBContext);

        //            if (!_schoolDBContext.Roles.Any(r => r.Name == role))
        //            {
        //                await roleStore.CreateAsync(new IdentityRole(role));
        //            }
        //        }
        //    }

        //    public async Task SeedAdmin()
        //    {            
        //        var user = new AppUser
        //        {
        //            UserName = "Admin",
        //            SecurityStamp = Guid.NewGuid().ToString()
        //        };

        //        if (!_schoolDBContext.Users.Any(u => u.UserName == user.UserName))
        //        {
        //            var password = new PasswordHasher<AppUser>();
        //            var hashed = password.HashPassword(user, "P@ssw0rd");
        //            user.PasswordHash = hashed;

        //            var userStore = new UserStore<AppUser>(_schoolDBContext);
        //            var result = await userStore.CreateAsync(user);
        //        }
        //    }
    }
}

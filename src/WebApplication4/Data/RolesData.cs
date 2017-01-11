using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication4.Data
{
    public static class RolesData
    {

        public enum IRoles { Administrator, User };
        public static readonly string[] Roles = Enum.GetNames(typeof(IRoles));

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var created = await db.Database.EnsureCreatedAsync();

                if (!created)
                {
                    foreach (var role in Roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }
                }
            }
        }
        public static string getRole(IRoles x)
        {
            return Roles[(int)x];
        }

        public static async Task<string> GetRoleOfPrincipal(UserManager<ApplicationUser> userManager, IPrincipal user)
        {
            ApplicationUser appUser = await userManager.FindByNameAsync(user.Identity.Name);
            if (appUser != null)
            {
                IList<string> roles = await userManager.GetRolesAsync(appUser);

                if (roles.Count > 0)
                    return roles[0];
            }
            return "Guest";
        }

    }
   
}

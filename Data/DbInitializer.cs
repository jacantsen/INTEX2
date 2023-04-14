using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace INTEX2.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create the "Admin" role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Create the "AuthenticatedUser" role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("AuthenticatedUser"))
            {
                await roleManager.CreateAsync(new IdentityRole("AuthenticatedUser"));
            }

            // Create the "UnauthenticatedUser" role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("UnauthenticatedUser"))
            {
                await roleManager.CreateAsync(new IdentityRole("UnauthenticatedUser"));
            }
        }
    }
}

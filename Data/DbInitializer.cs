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

            // Create the "AuthenticatedUser" role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("UnauthenticatedUser"))
            {
                await roleManager.CreateAsync(new IdentityRole("UnauthenticatedUser"));
            }

            // Create an admin user if one doesn't exist
            var adminUserEmail = "Admin@test.com";
            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminUserEmail,
                    Email = adminUserEmail,
                    EmailConfirmed = true // Set email verification status to True
                };

                // Replace "AdminPassword123" with a strong password
                var result = await userManager.CreateAsync(adminUser, "DummyPassword123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

    }
}

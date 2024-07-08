using Microsoft.AspNetCore.Identity;

namespace Gestion_Patients.api.Data
{
    public class DatabaseSeeder
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public DatabaseSeeder(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<bool> EnsureOrganizerIsCreated()
        {
            if (await userManager.FindByNameAsync("organizer") is not null)
            {
                return true;
            }
            var user = new IdentityUser()
            {
                UserName = "organizer"
            };
            if (!await roleManager.RoleExistsAsync("organizer"))
            {
                await roleManager.CreateAsync(new IdentityRole("organizer"));
            }
            var result = await userManager.CreateAsync(user, "6yb64nOav4M?JmHzn");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "organizer");
                return true;
            }
            return false;
        }

        public async Task<bool> EnsurePractitionerIsCreated()
        {
            if (await userManager.FindByNameAsync("practitioner") is not null)
            {
                return true;
            }
            var user = new IdentityUser()
            {
                UserName = "practitioner"
            };
            if (!await roleManager.RoleExistsAsync("practitioner"))
            {
                await roleManager.CreateAsync(new IdentityRole("practitioner"));
            }
            var result = await userManager.CreateAsync(user, "6yb64nOav4M?JmHzn");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "practitioner");
                return true;
            }
            return false;
        }

        public async Task<bool> EnsureAdminIsCreated()
        {
            if (await userManager.FindByNameAsync("admin") is not null)
            {
                return true;
            }
            var user = new IdentityUser()
            {
                UserName = "admin"
            };
            if (!await roleManager.RoleExistsAsync("practitioner"))
            {
                await roleManager.CreateAsync(new IdentityRole("practitioner"));
            }
            if (!await roleManager.RoleExistsAsync("organizer"))
            {
                await roleManager.CreateAsync(new IdentityRole("organizer"));
            }
            var result = await userManager.CreateAsync(user, "6yb64nOav4M?JmHzn");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "practitioner");
                await userManager.AddToRoleAsync(user, "organizer");
                return true;
            }
            return false;
        }
    }
}

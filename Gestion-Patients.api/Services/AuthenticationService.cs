using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Gestion_Patients.api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AuthenticationService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor) 
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<SignInResult> Login(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);
            if(user is not null)
            {
                return await signInManager.PasswordSignInAsync(user, password, false, false);
            }
            return SignInResult.Failed;
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<bool> EnsureAdminCreated()
        {
            if(await userManager.FindByNameAsync("admin") is not null)
            {
                return true;
            }
            var user = new IdentityUser()
            {
                UserName = "admin"
            };
            var result = await userManager.CreateAsync(user, "6yb64nOav4M?JmHzn");
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public bool IsConnected(ClaimsPrincipal claimsPrincipal)
        {
            return signInManager.IsSignedIn(claimsPrincipal);
        }
    }
}

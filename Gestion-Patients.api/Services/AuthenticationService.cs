using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gestion_Patients.api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration config;
        public AuthenticationService(
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager, 
            IHttpContextAccessor httpContextAccessor, 
            IConfiguration config) 
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.config = config;
        }
        public async Task<string> Login(string username, string password)
        {
            try
            {
                var user = await userManager.FindByNameAsync(username);
                if (user is null)
                {
                    return "";
                }
                var result = await userManager.CheckPasswordAsync(user, password);
                if (result)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(config["Jwt:SecretKey"]!);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(
                        [
                            new (ClaimTypes.Name, user.UserName!),
                            new (ClaimTypes.Role, "organizer")
                        ]),
                        Expires = DateTime.UtcNow.AddHours(24),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }
            }
            catch
            {
                throw;
            }
            return "";
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
                await userManager.AddToRoleAsync(user, "organizer");
                return true;
            }
            return false;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gestion_Patients.api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration config;
        public AuthenticationService(UserManager<IdentityUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
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
                var roles = await userManager.GetRolesAsync(user);
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.UserName!)
                };
                foreach (var role in roles)
                {
                    claims.Add(new(ClaimTypes.Role, role));
                }
                if (result)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(config["Jwt:SecretKey"]!);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
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
    }
}

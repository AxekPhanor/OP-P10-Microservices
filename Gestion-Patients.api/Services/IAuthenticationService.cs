using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Gestion_Patients.api.Services
{
    public interface IAuthenticationService
    {
        Task<SignInResult> Login(string username, string password);
        Task Logout();
        Task<bool> EnsureAdminCreated();
        bool IsConnected(ClaimsPrincipal claimsPrincipal);
    }
}

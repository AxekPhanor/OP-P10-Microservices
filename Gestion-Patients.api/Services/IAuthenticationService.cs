using Microsoft.AspNetCore.Identity;

namespace Gestion_Patients.api.Services
{
    public interface IAuthenticationService
    {
        Task<SignInResult> Login(string username, string password);
        Task Logout();
        Task<bool> EnsureAdminCreated();
    }
}

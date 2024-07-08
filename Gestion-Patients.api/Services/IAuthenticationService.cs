namespace Gestion_Patients.api.Services
{
    public interface IAuthenticationService
    {
        Task<string> Login(string username, string password);
    }
}

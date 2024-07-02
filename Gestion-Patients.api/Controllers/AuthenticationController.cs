using Gestion_Patients.api.Models;
using Gestion_Patients.api.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Gestion_Patients.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        
        public AuthenticationController(IAuthenticationService authenticationService) 
        { 
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await authenticationService.Login(loginModel.Username, loginModel.Password);
            if (result.Succeeded) 
            { 
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await authenticationService.Logout();
            return Ok();
        }

        [HttpGet]
        [Route("IsConnected")]
        public IActionResult IsConnected()
        {
            try
            {
                return Ok(authenticationService.IsConnected(User));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.StackTrace} : {ex.Message}");
            }
            return BadRequest();
        }
    }
}

using Gestion_Patients.api.Models;
using Gestion_Patients.api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                var token = await authenticationService.Login(loginModel.Username, loginModel.Password);
                if (token != "")
                {
                    return Ok(new { value = token });
                }
            }
            catch (Exception ex)
            {
                return Problem();
            }
            return NotFound();
        }

        [HttpGet]
        [Route("IsConnected")]
        [Authorize("Bearer")]
        public IActionResult IsConnected()
        {
            return Ok();
        }
    }
}

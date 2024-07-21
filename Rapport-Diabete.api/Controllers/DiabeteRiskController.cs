using Microsoft.AspNetCore.Mvc;
using Rapport_Diabete.api.Models;
using Rapport_Diabete.api.Services;

namespace Rapport_Diabete.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiabeteRiskController : ControllerBase
    {
        private readonly DiabeteRiskService diabeteRiskService;
        public DiabeteRiskController(DiabeteRiskService diabeteRiskService)
        {
            this.diabeteRiskService = diabeteRiskService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromQuery] int id)
        {
            RiskEnum? risk = await diabeteRiskService.GetRisk(id, authorization);
            if (risk is null)
            {
                return NotFound("Patient not found");
            }
            return Ok(risk);
        }
    }
}

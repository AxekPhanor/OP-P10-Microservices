using Gestion_Patients.api.Models;
using Gestion_Patients.api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Gestion_Patients.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;
        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] PatientIntputModel input)
        {
            try
            {
                return Ok(await patientService.Create(input));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.StackTrace} : {ex.Message}");
                return Problem();
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var output = await patientService.Delete(id);
                if (output is not null)
                {
                    return Ok(output);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.StackTrace} : {ex.Message}");
                return Problem();
            }
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            try
            {
                var output = await patientService.GetById(id);
                if (output is not null)
                {
                    return Ok(output);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.StackTrace} : {ex.Message}");
                return Problem();
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] PatientIntputModel input)
        {
            try
            {
                var output = await patientService.Update(input, id);
                if (output is not null)
                {
                    return Ok(output);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.StackTrace} : {ex.Message}");
                return Problem();
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await patientService.All());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.StackTrace} : {ex.Message}");
                return Problem();
            }
        }
    }
}

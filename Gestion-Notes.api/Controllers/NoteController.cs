using Gestion_Notes.api.Models;
using Gestion_Notes.api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Notes.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("practitioner")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;
        public NoteController(INoteService noteService) 
        { 
            this.noteService = noteService;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] NoteInputModel inputModel)
        {
            try
            {
                return Ok(await noteService.Create(inputModel));
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpGet]
        [Route("GetNotes")]
        public async Task<IActionResult> GetNotes([FromQuery] int patientId)
        {
            try
            {
                return Ok(await noteService.GetNotes(patientId));
            }
            catch
            {
                return Problem();
            }
        }
    }
}

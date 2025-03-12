using BAL.Services;
using Microsoft.AspNetCore.Mvc;
using BAL.DTOs;
using BAL.Services;
using BAL.Interfaces; 

namespace EmployeeWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProjects()
        {
            var projects = await Task.Run(() => _projectService.GetAllProjects());
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            var project = await Task.Run(() => _projectService.GetProjectById(id));
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] ProjectDTO projectDTO)
        {
            await Task.Run(() => _projectService.AddProject(projectDTO));
            return CreatedAtAction(nameof(GetProject), new { id = projectDTO.Id }, projectDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectDTO projectDTO)
        {
            if (id != projectDTO.Id)
            {
                return BadRequest();
            }
            await Task.Run(() => _projectService.UpdateProject(projectDTO));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await Task.Run(() => _projectService.DeleteProject(id));
            return NoContent();
        }
    }
}

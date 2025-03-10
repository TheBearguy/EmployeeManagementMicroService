using BAL.DTOs;
using BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectController : Controller
    {
        private readonly EmployeeProjectService _employeeProjectService; 
        public EmployeeProjectController(EmployeeProjectService employeeProjectService)
        {
            _employeeProjectService = employeeProjectService; 
        }

        [HttpGet("{employeeId}")] 
        public async Task<ActionResult<IEnumerable<EmployeeProjectDTO>>> GetAllEmployeeProjects(int employeeId)
        {
            var employeeProjects = await Task.Run(() => _employeeProjectService.GetAllEmployeeProjects(employeeId));
            return Ok(employeeProjects);
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<IEnumerable<EmployeeProjectDTO>>> GetAllProjectEmployees(int projectId)
        {
            var projectEmployees = await Task.Run(() => _employeeProjectService.GetAllProjectEmployees(projectId));
            return Ok(projectEmployees);
        }

        [HttpPost("{employeeId}/{projectId}")]
        public async Task<IActionResult> AssignEmployeeToProject(int employeeId, int projectId)
        {
            await Task.Run(() => _employeeProjectService.AssignEmployeeToProject(employeeId, projectId));
            return NoContent();
        }
    }
}

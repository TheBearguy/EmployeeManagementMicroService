using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BAL.DTOs;
using BAL.Services; 

namespace EmployeeWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        {
            var employees = await Task.Run(() => _employeeService.GetAllEmployees());
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await Task.Run(() => _employeeService.GetEmployeeById(id));
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            await Task.Run(() => _employeeService.AddEmployee(employeeDTO));
            return CreatedAtAction(nameof(GetEmployee), new { id = employeeDTO.Id }, employeeDTO);    
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
            {
                return BadRequest();
            }
            await Task.Run(() => _employeeService.UpdateEmployee(employeeDTO));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await Task.Run(() => _employeeService.DeleteEmployee(id));
            return NoContent();
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public async Task<IActionResult> CreateEmployee()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Envalid Request");
            }
            else
            {
                BAL b = new BAL();
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,POC")] // only Admin or POC roles allowed
    public class EmployeeController : ControllerBase
    {
        [HttpGet("data")]
        public IActionResult GetData()
        {
            return Ok("Employee data accessed successfully.");
        }
    }
}

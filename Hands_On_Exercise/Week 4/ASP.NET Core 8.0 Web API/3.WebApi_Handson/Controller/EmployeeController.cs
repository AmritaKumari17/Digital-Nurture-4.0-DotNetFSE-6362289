using EmployeeApiDemo.Filters;
using EmployeeApiDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = GetStandardEmployeeList();

        private static List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1985, 1, 1),
                    Department = new Department { Id = 1, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "ASP.NET" }
                    }
                }
            };
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> Get()
        {
            // Simulate an exception to trigger exception filter
            throw new Exception("Demo exception");
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Employee emp)
        {
            if (emp == null)
                return BadRequest();

            employees.Add(emp);
            return CreatedAtAction(nameof(Get), emp);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return NotFound();

            existing.Name = emp.Name;
            existing.Salary = emp.Salary;
            existing.Permanent = emp.Permanent;
            existing.Department = emp.Department;
            existing.Skills = emp.Skills;
            existing.DateOfBirth = emp.DateOfBirth;

            return Ok(existing);
        }
    }
}

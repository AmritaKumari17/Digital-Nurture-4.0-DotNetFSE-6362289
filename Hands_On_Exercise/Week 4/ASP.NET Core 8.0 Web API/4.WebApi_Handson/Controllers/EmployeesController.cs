using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        // Static hardcoded employee list
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Jane", Department = "Finance", Salary = 60000 },
            new Employee { Id = 3, Name = "Mike", Department = "IT", Salary = 70000 }
        };

        // PUT: api/employees/2
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
                return BadRequest("Invalid employee id");

            // Update hardcoded employee values
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Salary = updatedEmployee.Salary;

            return Ok(existingEmployee);
        }
    }
}

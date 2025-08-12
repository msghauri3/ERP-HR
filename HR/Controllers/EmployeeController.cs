using HR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // In-memory employees list
        private static List<Employee1> employees = new List<Employee1>
        {
            new Employee1 { Id = 1, Name = "Qasim", Salary = 20000, Designation = "Developer" },
            new Employee1 { Id = 2, Name = "Sindhu", Salary = 30000, Designation = "Developer" },
            new Employee1 { Id = 3, Name = "Tatheer", Salary = 40000, Designation = "Developer" }
        };

        // GET: api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee1>> GetAll()
        {
            return employees;
        }

        // GET: api/employees/1
        [HttpGet("{id}")]
        public ActionResult<Employee1> GetById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return employee;
        }

        // POST: api/employees
        [HttpPost]
        public ActionResult<Employee1> Create(Employee1 employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        // DELETE: api/employees/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            employees.Remove(employee);
            return NoContent();
        }

        [HttpGet("Name")]
        public ActionResult<IEnumerable<Employee1>> GetGender()
        {
            var result = employees.Where(e => e.Designation == "Developer").ToList();

            if (!result.Any())
            {
                return NotFound();
            }

            return result;
        }
    }
}

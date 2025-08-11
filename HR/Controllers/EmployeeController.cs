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
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Qasim", Salary = 20000, Designation = "Developer" },
            new Employee { Id = 2, Name = "Sindhu", Salary = 30000, Designation = "Developer" },
            new Employee { Id = 3, Name = "Tatheer", Salary = 40000, Designation = "Developer" }
        };

        // GET: api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return employees;
        }

        // GET: api/employees/1
        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return employee;
        }

        // POST: api/employees
        [HttpPost]
        public ActionResult<Employee> Create(Employee employee)
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
    }
}

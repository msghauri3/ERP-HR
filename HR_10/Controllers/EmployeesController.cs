// Controllers/EmployeesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_10.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly HRContext _context;

        public EmployeesController(HRContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/Employees/by-employeeid/{employeeId}
        [HttpGet("by-employeeid/{employeeId}")]
        public async Task<ActionResult<Employee>> GetEmployeeByEmployeeId(string employeeId)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeID == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/Employees/search?name={name}
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _context.Employees.ToListAsync();
            }

            var employees = await _context.Employees
                .Where(e => e.EmployeeName.Contains(name) || e.EmployeeID.Contains(name))
                .ToListAsync();

            return employees;
        }

        // GET: api/Employees/department/{department}
        [HttpGet("department/{department}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByDepartment(string department)
        {
            var employees = await _context.Employees
                .Where(e => e.Department == department)
                .ToListAsync();

            return employees;
        }

        // GET: api/Employees/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetActiveEmployees()
        {
            var employees = await _context.Employees
                .Where(e => e.EmployeeStatus == "Active" || e.EmployeeStatus == "active")
                .ToListAsync();

            return employees;
        }
    }
}
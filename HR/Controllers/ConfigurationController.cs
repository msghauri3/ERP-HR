using HR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly PayrollContext _context;
        public ConfigurationController(PayrollContext context) => _context = context;


        public async Task<IActionResult> Index()
        {
            var list = await _context.Configurations.ToListAsync();
            return View(list);
        }



        // GET: /Configurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var configuration = await _context.Configurations
                .FirstOrDefaultAsync(c => c.Uid == id.Value);

            if (configuration == null) return NotFound();

            return View(configuration);
        }



    }
}

using HR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly PayrollContext _context;

        public ConfigurationController(PayrollContext context)
        {
            _context = context;
        }

        // GET: api/Configuration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configuration>>> GetConfigurations()
        {
            return await _context.Configurations.ToListAsync();
        }

        // GET: api/Configuration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Configuration>> GetConfiguration(int id)
        {
            var configuration = await _context.Configurations
                .FirstOrDefaultAsync(c => c.Uid == id);

            if (configuration == null)
            {
                return NotFound();
            }

            return configuration;
        }


        // POST: api/Configuration
        [HttpPost]
        public async Task<ActionResult<Configuration>> PostConfiguration(Configuration configuration)
        {
            _context.Configurations.Add(configuration);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConfiguration),
                new { id = configuration.Uid }, configuration);
        }

        // PUT: api/Configuration/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguration(int id, Configuration configuration)
        {
            if (id != configuration.Uid)
            {
                return BadRequest();
            }

            _context.Entry(configuration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigurationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Configuration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguration(int id)
        {
            var configuration = await _context.Configurations.FindAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }

            _context.Configurations.Remove(configuration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfigurationExists(int id)
        {
            return _context.Configurations.Any(e => e.Uid == id);
        }


        [HttpGet("designations")]
        public async Task<ActionResult<IEnumerable<Configuration>>> GetDesignations()
        {
            var result = await _context.Configurations
                .Where(c => c.ConfigKey == "Designation")
                .ToListAsync();

            if (!result.Any())
            {
                return NotFound();
            }

            return result;
        }









    }
}
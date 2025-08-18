using DevExpress.XtraReports;
using HR_10.Models;
using HR_10.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly HRContext _context;

        public ConfigurationsController(HRContext context)
        {
            _context = context;
        }



        [HttpGet("Configurations")]
        public IActionResult GetConfigurations()
        {
            var report = new ReportConfiguration();
            using var stream = new MemoryStream();
            report.ExportToPdf(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream.ToArray(), "application/pdf", "ElectricityBill.pdf");
        }


    }
}

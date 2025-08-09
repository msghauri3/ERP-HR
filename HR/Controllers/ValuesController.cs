using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("Get")]
        public string Get()
        {
            return "Hello From Get";
        }


        [HttpGet("Get1")]
        public string Get1()
        {
            return "Hello From Get1";
        }

    }
}

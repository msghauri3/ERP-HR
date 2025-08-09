using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BTK01Controller : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "I Love Pakistan";
        }


        [HttpGet("Get1")]
        public string Get1()
        {
            return "I Love Karach";
        }


    }
}

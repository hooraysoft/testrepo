
using Microsoft.AspNetCore.Mvc;

namespace TinyUrlWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Links : Controller
    {
        [HttpPost]
        public IActionResult CreateLink()
        {
            Console.WriteLine("You hit the CreateLink method");
            return Ok("Link created");
        }
    }
}

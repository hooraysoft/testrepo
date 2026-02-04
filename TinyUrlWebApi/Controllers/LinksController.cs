
using Microsoft.AspNetCore.Mvc;
using TinyUrlWebApi.Requests;

namespace TinyUrlWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinksController : Controller
    {
        [HttpPost]
        public IActionResult CreateLink(CreateLinkRequest request)
        {
            Console.WriteLine($"Request: {request.Code} : {request.LinkUrl}");



            return Ok("Link created");
        }

    }
}

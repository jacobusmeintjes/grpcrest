using Microsoft.AspNetCore.Mvc;

namespace helloworldrest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : Controller
    {
        [HttpGet]
        public IActionResult Index(string name)
        {
            return Ok($"Hello {name}");
        }
    }
}

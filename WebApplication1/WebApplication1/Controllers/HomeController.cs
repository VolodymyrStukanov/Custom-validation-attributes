using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using ValidationAttribute = WebApplication1.Validation.ValidationAttributes.ValidationAttribute;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpPost("CreateMyModel")]
        [Validation]
        public IActionResult CreateMyModel(MyModel model)
        {
            return Ok();
        }
    }
}

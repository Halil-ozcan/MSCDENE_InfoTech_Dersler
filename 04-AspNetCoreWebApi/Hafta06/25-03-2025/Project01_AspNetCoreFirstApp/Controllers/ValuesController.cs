using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project01_AspNetCoreFirstApp.Controllers
{
    //localhost:5200/api/values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IActionResult Hello()
        {
            return Ok("Merhaba Dünya");
        }
    }
}

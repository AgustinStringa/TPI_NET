using Microsoft.AspNetCore.Mvc;
using API.Model;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AreaController : Controller
    {
        [HttpGet]
        public Area GetArea()
        {
            return new Area { };
        }
    }
}

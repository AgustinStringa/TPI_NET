using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            try
            {
                var context = new API.AcademiaContext();
                return await context.Courses.Include(c => c.Subject).ToListAsync();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
                throw e;
            }
        }
    }
}

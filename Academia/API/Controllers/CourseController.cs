using ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        [HttpPost("availablecourses")]
        public async Task<IEnumerable<Course>> GetAvailableCourses(User user)
        {
            var context = new AcademiaContext();
            var studentIdParameter = new SqlParameter("@id_alumno", user.Id);
            var courses = await context.Courses.FromSqlRaw<Course>("GetAvailableCourses @id_alumno", studentIdParameter).ToListAsync();
            foreach (var course in courses)
            {
                await context.Entry(course).Reference(c => c.Subject).LoadAsync();
            }
            return courses;
        }
    }
}

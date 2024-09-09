using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/usercourses")]
    [ApiController]
    public class UserCourseController : Controller
    {
        private readonly UserCourseService _userCourseService;
        private readonly AcademiaContext _context;

        public UserCourseController(UserCourseService userCourseService, AcademiaContext context)
        {
            _userCourseService = userCourseService;
            _context = context;
        }

        [HttpPost("enroll")]
        public async Task<ActionResult> Enroll([FromBody] UserCourseDto userCourseDto)
        {
            try
            {
                var user = await _context.Users.FindAsync(userCourseDto.UserId);
                var course = await _context.Courses.FindAsync(userCourseDto.CourseId);

                if (user == null || course == null)
                {
                    return NotFound(new { message = "User or course not found" });
                }

                var userCourse = new UserCourse
                {
                    UserId = userCourseDto.UserId,
                    CourseId = userCourseDto.CourseId,
                    Status = "inscripto"
                };

                // Check if the user is already enrolled
                var isEnrolled = await _userCourseService.IsUserAlreadyEnrolled(userCourse.UserId, userCourse.CourseId, course.CalendarYear);
                if (isEnrolled)
                {
                    return Conflict(new { message = "User is already enrolled in this course under the specified conditions" });
                }

                await _userCourseService.Add(userCourse);

                return Ok(new { message = "Enrollment successful" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("unenroll/{userId}/{courseId}")]
        public async Task<ActionResult> Unenroll(int userId, int courseId)
        {
            try
            {
                await _userCourseService.Delete(userId, courseId);
                return Ok(new { message = "Unenrollment successful" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{userId}/{courseId}")]
        public async Task<ActionResult<UserCourse>> GetByUserAndCourse(int userId, int courseId)
        {
            try
            {
                var userCourse = await _context.UserCourses
                    .Include(uc => uc.Course)
                    .FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CourseId == courseId);

                if (userCourse == null)
                {
                    return NotFound(new { message = "User course enrollment not found" });
                }

                return Ok(userCourse);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }

    public class UserCourseDto
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}

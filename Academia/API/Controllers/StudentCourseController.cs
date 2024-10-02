using ApplicationCore.Model;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/student-courses")]
	[ApiController]
	public class StudentCourseController : Controller
	{
		private readonly StudentCourseService userCourseService;

		public StudentCourseController(StudentCourseService userCourseService)
		{
			this.userCourseService = userCourseService;
		}

		//[HttpPost("enroll")]
		//public async Task<ActionResult> Enroll([FromBody] UserCourseDto userCourseDto)
		//{
		//    try
		//    {
		//        var user = await context.Users.FindAsync(userCourseDto.UserId);
		//        var course = await context.Courses.FindAsync(userCourseDto.CourseId);

		//        if (user == null || course == null)
		//        {
		//            return NotFound(new { message = "User or course not found" });
		//        }

		//        var userCourse = new UserCourse
		//        {
		//            UserId = userCourseDto.UserId,
		//            CourseId = userCourseDto.CourseId,
		//            Status = "inscripto"
		//        };

		//        // Check if the user is already enrolled
		//        var isEnrolled = await userCourseService.IsUserAlreadyEnrolled(userCourse.UserId, userCourse.CourseId, course.CalendarYear);
		//        if (isEnrolled)
		//        {
		//            return Conflict(new { message = "User is already enrolled in this course under the specified conditions" });
		//        }

		//        await userCourseService.Add(userCourse);

		//        return Ok(new { message = "Enrollment successful" });
		//    }
		//    catch (Exception e)
		//    {
		//        return StatusCode(500, new { message = e.Message });
		//    }
		//}

		//[HttpDelete("unenroll/{userId}/{courseId}")]
		//public async Task<ActionResult> Unenroll(int userId, int courseId)
		//{
		//    try
		//    {
		//        await userCourseService.Delete(userId, courseId);
		//        return Ok(new { message = "Unenrollment successful" });
		//    }
		//    catch (Exception e)
		//    {
		//        return StatusCode(500, new { message = e.Message });
		//    }
		//}

		//[HttpGet("{userId}/{courseId}")]
		//public async Task<ActionResult<UserCourse>> GetByUserAndCourse(int userId, int courseId)
		//{
		//    try
		//    {
		//        var userCourse = await context.UserCourses
		//            .Include(uc => uc.Course)
		//            .FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CourseId == courseId);

		//        if (userCourse == null)
		//        {
		//            return NotFound(new { message = "User course enrollment not found" });
		//        }

		//        return Ok(userCourse);
		//    }
		//    catch (Exception e)
		//    {
		//        return StatusCode(500, new { message = e.Message });
		//    }
		//}
		[HttpGet("${id}")]
		public async Task<ActionResult<StudentCourse>> GetById(int id)
		{
			try
			{
				return await userCourseService.GetById(id);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPost]
		public async Task<ActionResult<StudentCourse>> Create(StudentCourse newUserCourse)
		{
			try
			{
				await userCourseService.Create(newUserCourse);
				return CreatedAtAction(nameof(GetById), new { id = newUserCourse.Id }, newUserCourse);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}


		//delete -> para permitir a usuario desinscribirse
		//validar que el usuario sea el propietario del cursado a eliminar
		//recibir en el cuerpo del delete o de algun modo
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var deletedUserCourse = await userCourseService.GetById(id);
				if (deletedUserCourse == null)
				{
					return NotFound();
				}
				await userCourseService.Delete(deletedUserCourse.Id);
				return NoContent();
			}
			catch (Exception e)
			{
				if ((e.InnerException as SqlException).ErrorCode == -2146232060)
				{
					return StatusCode(400, new { message = "Can't delete a Subject with related Courses" });
				}
				else
				{
					return StatusCode(500, new { message = e.Message });
				}
			}
		}


		[HttpGet()]
		public async Task<ActionResult<IEnumerable<StudentCourse>>> GetByUserId([FromQuery] int? userId = null)
		{
			try
			{
				if (userId != null)
				{
					var userCourses = await userCourseService.GetByUserId((int)userId);

					if (userCourses == null)
					{
						return NotFound(new { message = "there is no inscriptions for this student" });
					}
					return Ok(userCourses);
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
			}
		}

		[HttpPatch("{userCourseId}")]
		public async Task<ActionResult<StudentCourse>> QualifyCourse(int userCourseId, CalificationCourse calification)
		{
			try
			{
				var userCourse = await userCourseService.GetById(userCourseId);

				if (userCourse == null)
				{
					return NotFound(new { message = "inscription not found" });
				}
				var updatedUsercourse = await userCourseService.QualifyCourse(userCourseId, calification);

				return Ok(updatedUsercourse);
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

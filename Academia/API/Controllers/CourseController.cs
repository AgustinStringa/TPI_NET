using ApplicationCore.Model;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/courses")]
	[ApiController]
	public class CourseController : Controller
	{
		private CourseService courseService;
		public CourseController(CourseService course)
		{
			this.courseService = course;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Course>>> GetAll()
		{
			try
			{
				var courses = await courseService.GetAll();
				return Ok(courses);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Course>> GetById(int id)
		{
			try
			{
				var course = await courseService.GetById(id);
				if (course == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(course);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPost]
		public async Task<ActionResult<Course>> Create(Course newCourse)
		{
			try
			{
				await courseService.Create(newCourse);
				return CreatedAtAction(nameof(GetById), new { id = newCourse.Id }, newCourse); ;
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Course>> Delete(int id)
		{
			try
			{
				var deletedCourse = await courseService.GetById(id);
				if (deletedCourse == null)
				{
					return NotFound();
				}
				else
				{
					await courseService.Delete(deletedCourse.Id);
					return NoContent();
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Course>> Update(int id, Course updatedCourse)
		{
			try
			{
				var existingCourse = await courseService.GetById(id);
				if (existingCourse == null)
				{
					return NotFound();
				}
				foreach (var prop in updatedCourse.GetType().GetProperties())
				{
					if (prop.Name != "Id" && prop.Name != "Subjects" && prop.Name != "Commissions")
					{
						prop.SetValue(existingCourse, prop.GetValue(updatedCourse));
					}
				}

				await courseService.Update(existingCourse);
				return NoContent();

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

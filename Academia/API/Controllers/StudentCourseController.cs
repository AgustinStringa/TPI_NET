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

		[HttpGet("academic-status/{id}")]
		public async Task<ActionResult<object>> GetEstadoAcademico(int id)
		{
			try
			{
				var usercourses = await userCourseService.GetAcademicStatus(id);
				return Ok(usercourses);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

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
				return StatusCode(500, new { message = e.Message });
			}
		}


		[HttpGet()]
		public async Task<ActionResult<IEnumerable<StudentCourse>>> GetActivesByUserId([FromQuery] int? userId = null, [FromQuery] bool? actives = false)
		{
			try
			{
				if (userId != null)
				{
					var userCourses = await userCourseService.GetByUserId((int)userId, (bool)actives);

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

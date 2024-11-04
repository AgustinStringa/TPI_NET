using ApplicationCore.Model;
using ApplicationCore;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/users/teachers")]
	[ApiController]
	public class TeacherController : Controller
	{
		private TeacherService teacherService;
		private UserService userService;
		public TeacherController(UserService userService, TeacherService teacherService)
		{
			this.teacherService = teacherService;
			this.userService = userService;
		}

		[HttpPost]
		public async Task<ActionResult<Teacher>> CreateTeacher(Teacher teacher)
		{
			try
			{
				teacher.Password = Util.EncodePassword(teacher.Password);
				await teacherService.Create(teacher);
				return CreatedAtAction(
				nameof(GetTeacherById),
				new { id = teacher.Id }, teacher);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.InnerException.Message });
				throw e;
			}
		}

		[HttpGet()]
		//[Authorize]
		public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
		{
			try
			{
				var teachers = await teacherService.GetAll();
				return Ok(teachers);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Teacher>> GetTeacherById(int id)
		{
			try
			{
				var user = await teacherService.GetById(id);
				if (user == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(user);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Teacher>> UpdateTeacher(Teacher teacher)
		{
			try
			{
				var existingTeacher = await teacherService.GetById(teacher.Id);
				if (existingTeacher == null)
				{
					return NotFound();
				}
				await teacherService.Update(teacher);
				return Ok();
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.InnerException.Message });
				throw e;
			}
		}
	}
}

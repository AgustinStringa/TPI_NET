using ApplicationCore;
using ApplicationCore.Model;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/users/students")]
	[ApiController]
	public class StudentController : Controller
	{
		private StudentService studentService;
		private UserService userService;
		public StudentController(StudentService studentService, UserService userService)
		{
			this.studentService = studentService;
			this.userService = userService;
		}

		[HttpGet("")]
		//[Authorize]
		public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
		{
			try
			{
				var students = await studentService.GetAll();
				return Ok(students);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Student>> GetStudentById(int id)
		{
			try
			{
				var user = await studentService.GetById(id);
				return Ok(user);

			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPost()]
		public async Task<ActionResult<Student>> CreateStudent(Student student)
		{
			try
			{
				student.Password = Util.EncodePassword(student.Password);
				await studentService.Create(student);
				return CreatedAtAction(
				nameof(GetStudentById),
				new { id = student.Id }, student);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.InnerException.Message });
				throw e;
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Student>> UpdateStudent(Student student)
		{
			try
			{
				var existingStudent = await studentService.GetById(student.Id);
				if (existingStudent == null)
				{
					return NotFound();
				}
				await studentService.Update(student);
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

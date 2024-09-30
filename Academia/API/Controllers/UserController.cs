using ApplicationCore.Model;
using ApplicationCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using ApplicationCore.Services;

namespace API.Controllers
{

	public class LoginDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public LoginDto() { }
	}

	public class UserDTO
	{
		public int Id { get; set; }	
		public string Name { get; set; }
		public string Role { get; set; }
		public string Lastname { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public DateTime BirthDate { get; set; }
		public string? StudentId { get; set; }
		public string? TeacherId { get; set; }
		public string? Cuit { get; set; }
	}


	[Route("api/users")]
	[ApiController]
	public class UserController : Controller
	{
		private UserService userService;
		private StudentService studentService;
		private TeacherService teacherService;
		private AdministrativeService administrativeService;
		public UserController(UserService userService, StudentService studentService,
			TeacherService teacherService, AdministrativeService administrativeService)
		{
			this.userService = userService;
			this.studentService = studentService;
			this.teacherService = teacherService;
			this.administrativeService = 
			this.administrativeService = administrativeService;
		}

		[HttpGet]
		//[Authorize]
		public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
		{
			try
			{
				var users = await userService.GetAll();
				var usersDto = users.Select(
					u => new UserDTO
					{
						Id = u.Id,
						Address = u.Address,
						BirthDate = u.BirthDate,
						Cuit = (u as Teacher)?.Cuit ?? (u as Administrative)?.Cuit ?? null,
						StudentId = (u as Student)?.StudentId ?? null,
						TeacherId = (u as Teacher)?.TeacherId ?? null,
						Email = u.Email,
						Lastname = u.Lastname,
						Username = u.Username,
						Name = u.Name,
						PhoneNumber = u.PhoneNumber,
						Role = ((u as Teacher) != null ? "Teacher" : null ?? (
					(u as Student) != null ? "Student" : null)
					?? (u as Administrative != null ? "Administrative" : null)
					)
					}
					).ToList();
				return Ok(usersDto);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetById(int id)
		{
			try
			{
				var user = await userService.GetById(id);
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

		[HttpDelete("{id}")]
		public async Task<ActionResult<User>> Delete(int id)
		{
			try
			{
				var user = await userService.GetById(id);
				if (user == null)
				{
					return NotFound();
				}
				await userService.Delete(id);
				return NoContent();
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.InnerException.Message });
				throw e;
			}
		}


		[HttpGet("students")]
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

		[HttpGet("students/{id}")]
		public async Task<ActionResult<User>> GetStudentById(int id)
		{
			try
			{
				var user = await studentService.GetById(id);
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


		[HttpGet("teachers")]
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
		[HttpGet("teachers/{id}")]
		public async Task<ActionResult<User>> GetTeacherById(int id)
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

		[HttpGet("administratives")]
		//[Authorize]
		public async Task<ActionResult<IEnumerable<Teacher>>> GetAdministratives()
		{
			try
			{
				var administratives = await administrativeService.GetAll();
				return Ok(administratives);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}
		[HttpGet("administratives/{id}")]
		public async Task<ActionResult<Administrative>> GetAdministrativeById(int id)
		{
			try
			{
				var administrative = await administrativeService.GetById(id);
				if (administrative == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(administrative);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}


		[HttpPost("auth")]
		public async Task<ActionResult<object>> Auth(LoginDto credentials)
		{
			try
			{

				var user = await userService.GetByUsername(credentials.Username);
				if (user != null)
				{
					var authUser = await userService.ValidateCredentials(user.Username, credentials.Password);
					if (authUser != null)
					{
						var jwt = API.Helpers.AuthHelpers.GenerateJWTToken(user);
						return Ok(new
						{
							User = authUser,
							Jwt = jwt
						});

					}
					else
					{
						return StatusCode(401, new { message = "username or password wrong" });
					}

				}
				else
				{
					return StatusCode(401, new { message = "username or password wrong" });

				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPost("students")]
		public async Task<ActionResult<User>> CreateStudent(Student student)
		{
			try
			{
				student.Password = Util.EncodePassword(student.Password);
				await userService.CreateStudent(student);
				return CreatedAtAction(
				nameof(GetById),
				new { id = student.Id }, student);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.InnerException.Message });
				throw e;
			}
		}

		[HttpPost("teachers")]
		public async Task<ActionResult<User>> CreateTeacher(Teacher teacher)
		{
			try
			{
				teacher.Password = Util.EncodePassword(teacher.Password);
				await userService.CreateTeacher(teacher);
				return CreatedAtAction(
				nameof(GetById),
				new { id = teacher.Id }, teacher);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.InnerException.Message });
				throw e;
			}
		}

		[HttpPost("administratives")]
		public async Task<ActionResult<User>> CreateAdmnistrative(Administrative administrative)
		{
			try
			{
				administrative.Password = Util.EncodePassword(administrative.Password);
				await userService.CreateAdministrative(administrative);
				return CreatedAtAction(
				nameof(GetById),
				new { id = administrative.Id }, administrative);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.InnerException.Message });
				throw e;
			}
		}
	}
}

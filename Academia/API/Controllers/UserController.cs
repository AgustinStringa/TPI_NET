using ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using ApplicationCore.Services;
using System.Data;

namespace API.Controllers
{


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
		public async Task<ActionResult<ApplicationCore.Model.User>> GetById(int id)
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


	}
}

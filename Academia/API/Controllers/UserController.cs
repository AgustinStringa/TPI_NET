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

	[Route("api/users")]
	[ApiController]
	public class UserController : Controller
	{
		private UserService userService;
		public UserController(UserService userService)
		{
			this.userService = userService;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<User>>> GetAll()
		{
			try
			{
				var users = await userService.GetAll();
				return Ok(users);
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

		[HttpPost()]
		public async Task<ActionResult<User>> Create(User newUser)
		{
			try
			{
				newUser.Password = Util.EncodePassword(newUser.Password);
				await userService.Create(newUser);
				return CreatedAtAction(
				nameof(GetById),
				new { id = newUser.Id }, newUser);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.InnerException.Message });
				throw e;
			}
		}
	}
}

using ApplicationCore.Model;
using ApplicationCore;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Services;

namespace API.Controllers
{
	[Route("api/users/administratives")]
	[ApiController]
	public class AdministrativeController : Controller
	{
		private AdministrativeService administrativeService;
		private UserService userService;
		public AdministrativeController(StudentService studentService, AdministrativeService administrativeService, UserService userService)
		{
			this.administrativeService = administrativeService;
			this.userService = userService;
		}

		[HttpGet]
		//[Authorize]
		public async Task<ActionResult<IEnumerable<Administrative>>> GetAdministratives()
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

		[HttpGet("{id}")]
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


		[HttpPost]
		public async Task<ActionResult<Administrative>> CreateAdmnistrative(Administrative administrative)
		{
			try
			{
				administrative.Password = Util.EncodePassword(administrative.Password);
				await administrativeService.Create(administrative);
				return CreatedAtAction(
				nameof(GetAdministrativeById),
				new { id = administrative.Id }, administrative);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.InnerException.Message });
				throw e;
			}
		}
		
		[HttpPut("{id}")]
		public async Task<ActionResult<Administrative>> UpdateAdministrative(Administrative administrative)
		{
			try
			{
				var existingAdministrative = await administrativeService.GetById(administrative.Id);
				if (existingAdministrative == null)
				{
					return NotFound();
				}
				await administrativeService.Update(administrative);
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

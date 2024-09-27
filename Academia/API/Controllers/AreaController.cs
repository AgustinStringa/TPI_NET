using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ApplicationCore.Services;

namespace API.Controllers
{
	[Route("api/areas")]
	[ApiController]
	public class AreaController : Controller
	{
		private readonly AreaService areaService;

		public AreaController(AreaService areaService)
		{
			this.areaService = areaService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Area>>> GetAll()
		{
			try
			{
				var areas = await areaService.GetAll();
				if (areas == null) return NotFound();

				return Ok(areas);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Area>> GetById(int id)
		{
			try
			{
				var area = await areaService.GetById(id);
				if (area == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(area);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPost]
		public async Task<ActionResult<Area>> Create(Area newArea)
		{
			try
			{
				await areaService.Create(newArea);
				return CreatedAtAction(nameof(GetById), new { id = newArea.Id }, newArea);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var deletedArea = await areaService.GetById(id);
				if (deletedArea == null)
				{
					return NotFound();
				}
				await areaService.Delete(deletedArea.Id);
				return NoContent();
			}
			catch (Exception e)
			{
				//TO DO: revisar
				if ((e.InnerException as SqlException).ErrorCode == -2146232060)
				{
					return StatusCode(400, new { message = "Can't delete an Area with related Curriculums" });
				}
				else
				{
					return StatusCode(500, new { message = e.Message });
				}
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Area updatedArea)
		{
			try
			{
				var area = await areaService.GetById(id);
				if (area == null)
				{
					return NotFound();
				}
				foreach (var prop in updatedArea.GetType().GetProperties())
				{
					if (prop.Name != "Id" && prop.Name != "Curriculums")
					{
						prop.SetValue(area, prop.GetValue(updatedArea));
					}
				}
				await areaService.Update(area);
				return NoContent();
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}
	}
}

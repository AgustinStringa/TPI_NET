using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Services;

namespace API.Controllers
{
	[Route("api/commissions")]
	[ApiController]
	public class CommissionController : Controller
	{
		private CommissionService commissionService;

		public CommissionController(CommissionService commissionService)
		{
			this.commissionService = commissionService;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Commission>>> GetAll([FromQuery] string? populate = "", [FromQuery] int? curriculumId = null, [FromQuery] int? level = null)
		{
			try
			{
				var populateEntities = populate?.Split(',') ?? new string[0];

				var commissions = await commissionService.GetAll(
					new CommissionRequestParams
					{
						Populate = new CommissionRequestParamsPopulate
						{
							curriculum = populateEntities.Contains("curriculum"),

						},
						coursesCount = populateEntities.Contains("courses-count"),
						curriculumId = curriculumId,
						level = level
					}
					);
					
				return Ok(commissions);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Commission>> GetById(int id)
		{
			try
			{

				var commission = await commissionService.GetById(id);
				if (commission == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(commission);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPost]
		public async Task<ActionResult<Commission>> Create(Commission newCommission)
		{
			try
			{

				await commissionService.Create(newCommission);
				return CreatedAtAction(
					nameof(GetById),
					new { id = newCommission.Id }, newCommission);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var deletedCommission = await commissionService.GetById(id);
				if (deletedCommission == null)
				{
					return NotFound();
				}
				await commissionService.Delete(id);
				return NoContent();
			}
			catch (Exception e)
			{
				//throw e;
				return StatusCode(500, new { message = e.Message });
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Commission updatedCommission)
		{
			try
			{

				var existingCommission = await commissionService.GetById(id);
				if (existingCommission == null)
				{
					return NotFound();
				}
				foreach (var prop in updatedCommission.GetType().GetProperties())
				{
					if (prop.Name != "Id" && prop.Name != "Courses")
					{
						prop.SetValue(existingCommission, prop.GetValue(updatedCommission));
					}
				}
				await commissionService.Update(existingCommission);
				return NoContent();
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
			}
		}

		[HttpGet("curriculum-id/{curriculumId}/level/{level}")]
		public async Task<ActionResult<IEnumerable<Commission>>> GetByCurriculumIdAndLevel(int curriculumId, int level)
		{
			try
			{

				var commissions = await commissionService.GetByCurriculumIdAndLevel(curriculumId, level);
				if (commissions == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(commissions);
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

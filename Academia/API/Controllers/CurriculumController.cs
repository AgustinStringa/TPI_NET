using ApplicationCore.Model;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/curriculums")]

	[ApiController]
	public class CurriculumController(CurriculumService curriculumService) : Controller
	{
		private readonly CurriculumService curriculumService = curriculumService;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Curriculum>>> GetAll([FromQuery] string? populate = "", [FromQuery] int? areaId = null)
		{
			try
			{
				var populateEntities = populate?.Split(',') ?? new string[0];
				var curriculums = await curriculumService.GetAll(
					new CurriculumRequestParams
					{
						Populate = new CurriculumRequestParamsPopulate
						{
							area = populateEntities.Contains("area"),
							students = populateEntities.Contains("students"),
							subjectsCount = populateEntities.Contains("subjects-count"),
							commissionsCount = populateEntities.Contains("commissionsCount"),
						},
						AreaId = areaId != null ? areaId : null,
					});
				return Ok(curriculums);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Curriculum>> GetById(int id)
		{
			try
			{
				var curriculum = await curriculumService.GetById(id);
				if (curriculum == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(curriculum);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPost]
		public async Task<ActionResult<Curriculum>> Create(Curriculum newCurriculum)
		{
			try
			{
				await curriculumService.Create(newCurriculum);
				return CreatedAtAction(
				nameof(GetById),
				new { id = newCurriculum.Id }, newCurriculum);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}

		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Curriculum updatedCurriculum)
		{
			try
			{

				var curriculum = await curriculumService.GetById(id);
				if (curriculum == null)
				{
					return NotFound();
				}
				foreach (var prop in updatedCurriculum.GetType().GetProperties())
				{
					if (prop.Name == "UserCourses")
					{
						throw new Exception();
					}
					if (prop.Name != "Id" && prop.Name != "Subjects" && prop.Name != "Commissions")
					{
						prop.SetValue(curriculum, prop.GetValue(updatedCurriculum));
					}
				}

				await curriculumService.Update(curriculum);

				return NoContent();
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
				var deletedCurriculum = await curriculumService.GetById(id);
				if (deletedCurriculum == null)
				{
					return NotFound();
				}
				await curriculumService.Delete(deletedCurriculum.Id);
				return NoContent();
			}
			catch (Exception e)
			{
				if ((e.InnerException as SqlException).ErrorCode == -2146232060)
				{
					return StatusCode(400, new { message = "Can't delete a Curriculum with related Subjects, Students or Commissions" });
				}
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpGet("area-id/{id}")]
		public async Task<ActionResult<IEnumerable<Curriculum>>> GetByAreaId(int id)
		{
			try
			{
				var curriculums = await curriculumService.GetByAreaId(id);
				if (curriculums == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(curriculums);
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

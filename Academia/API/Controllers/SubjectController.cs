using ApplicationCore.Model;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
	[Route("api/subjects")]
	[ApiController]
	public class SubjectController : Controller
	{
		private readonly SubjectService subjectService;

		public SubjectController(SubjectService subjectService)
		{
			this.subjectService = subjectService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Subject>>> GetAll([FromQuery] string? populate = "", [FromQuery] int? curriculumId = null)
		{
			try
			{
				var populateEntities = populate?.Split(',') ?? new string[0];

				var subjects = await subjectService.GetAll(new SubjectRequestParams
				{
					Populate = new SubjectRequestParamsPopulate
					{
						coursesCount = populateEntities.Contains("courses-count"),
						curriculum = populateEntities.Contains("curriculum")

					},
					CurriculumId = curriculumId != null ? curriculumId : null
				}
				);
				//if (subjects == null) return NotFound();

				return Ok(subjects);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Subject>> GetById(int id)
		{
			try
			{
				var subject = await subjectService.GetById(id);
				if (subject == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(subject);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPost]
		public async Task<ActionResult<Subject>> Create(Subject newSubject)
		{
			try
			{
				await subjectService.Create(newSubject);
				return CreatedAtAction(nameof(GetById), new { id = newSubject.Id }, newSubject);
			}
			catch (Exception e)
			{
				return StatusCode(500, new { message = e.Message });
				throw e;
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Subject updatedSubject)
		{
			try
			{
				var subject = await subjectService.GetById(id);
				if (subject == null)
				{
					return NotFound();
				}
				foreach (var prop in updatedSubject.GetType().GetProperties())
				{
					if (prop.Name != "Id" && prop.Name != "Curriculum")
					{
						prop.SetValue(subject, prop.GetValue(updatedSubject));
					}
				}
				await subjectService.Update(subject);
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
				var deletedSubject = await subjectService.GetById(id);
				if (deletedSubject == null)
				{
					return NotFound();
				}
				await subjectService.Delete(deletedSubject.Id);
				return NoContent();
			}
			catch (Exception e)
			{
				if ((e.InnerException as SqlException).ErrorCode == -2146232060)
				{
					return StatusCode(400, new { message = "Can't delete a Subject with related Courses" });
				}
				else
				{
					return StatusCode(500, new { message = e.Message });
				}
			}
		}

		[HttpGet("curriculum-id/{id}")]
		public async Task<ActionResult<IEnumerable<Subject>>> GetByCurriculumId(int id)
		{
			try
			{
				var subjects = await subjectService.GetByCurriculumId(id);
				if (subjects == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(subjects);
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

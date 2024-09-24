using ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/curriculums")]

    [ApiController]
    public class CurriculumController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curriculum>>> GetAll()
        {
            try
            {
                var context = new API.AcademiaContext();
                return await context.Curriculums.Include(c => c.Area).ToListAsync();
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
                var context = new API.AcademiaContext();
                var curriculum = await context.Curriculums.FindAsync(id);
                if (curriculum == null)
                {
                    return NotFound();
                }
                else
                {
                    await context.Entry(curriculum).Reference(c => c.Area).LoadAsync();
                    return curriculum;
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
                var context = new API.AcademiaContext();
                context.Curriculums.Add(newCurriculum);
                await context.SaveChangesAsync();
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
                if (id != updatedCurriculum.Id)
                {
                    return BadRequest();
                }
                var context = new API.AcademiaContext();
                var curriculum = await context.Curriculums.FindAsync(id);
                if (curriculum == null)
                {
                    return NotFound();
                }
                //prop by prop        
                curriculum.Description = updatedCurriculum.Description;
                curriculum.Year = updatedCurriculum.Year;
                curriculum.Resolution = updatedCurriculum.Resolution;
                var area = await context.Areas.FindAsync(updatedCurriculum.AreaId);
                if (area != null)
                {
                    curriculum.AreaId = updatedCurriculum.AreaId;
                    curriculum.Area = area;
                }
                await context.SaveChangesAsync();
                return NoContent();
                //return Ok(curriculum);
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
                var context = new API.AcademiaContext();
                var deletedCurriculum = await context.Curriculums.FindAsync(id);
                if (deletedCurriculum == null)
                {
                    return NotFound();
                }
                context.Curriculums.Remove(deletedCurriculum);
                await context.SaveChangesAsync();
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

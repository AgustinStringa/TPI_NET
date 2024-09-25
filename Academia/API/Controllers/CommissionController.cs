using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/commissions")]
    [ApiController]
    public class CommissionController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commission>>> GetAll()
        {
            try
            {
                var context = new API.AcademiaContext();
                return await context.Commissions.Include(a => a.Courses).ToListAsync();
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
                var context = new API.AcademiaContext();
                var commission = await context.Commissions.FindAsync(id);
                if (commission == null)
                {
                    return NotFound();
                }
                else
                {
                    return commission;
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
                throw e;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Commission>> Create(Commission newComm)
        {
            try
            {
                var context = new API.AcademiaContext();
                context.Commissions.Add(newComm);
                context.SaveChangesAsync();
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = newComm.Id }, newComm);
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
                var deletedComm = await context.Commissions.FindAsync(id);
                if (deletedComm == null)
                {
                    return NotFound();
                }
                context.Commissions.Remove(deletedComm);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
                throw e;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Commission updatedComm)
        {
            try
            {
                if (id != updatedComm.Id)
                {
                    return BadRequest();
                }
                var context = new API.AcademiaContext();
                var commission = await context.Commissions.FindAsync(id);
                if (commission == null)
                {
                    return NotFound();
                }
                // idk
                commission.Description = updatedComm.Description;
                commission.IdCurriculum = updatedComm.IdCurriculum;
                commission.Courses = updatedComm.Courses;
                var curriculum = await context.Curriculums.FindAsync(updatedComm.IdCurriculum);
                if (curriculum != null)
                {
                    commission.IdCurriculum = updatedComm.IdCurriculum;
                    commission.Curriculum = curriculum;
                }
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

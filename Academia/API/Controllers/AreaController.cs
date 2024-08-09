using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    [Route("api/areas")]
    [ApiController]
    public class AreaController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAll()
        {
            try
            {
                var context = new AcademiaContext();
                return await context.Areas.Include(a => a.Curriculums).ToListAsync();
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
                var context = new AcademiaContext();
                var area = await context.Areas.FindAsync(id);
                if (area == null)
                {
                    return NotFound();
                }
                else
                {
                    return area;
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
                var context = new AcademiaContext();
                context.Areas.Add(newArea);
                await context.SaveChangesAsync();
                return CreatedAtAction(
                nameof(GetById),
                new { id = newArea.Id }, newArea);
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
                var context = new AcademiaContext();
                var deletedArea = await context.Areas.FindAsync(id);
                if (deletedArea == null)
                {
                    return NotFound();
                }
                context.Areas.Remove(deletedArea);
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
        public async Task<IActionResult> Update(int id, Area updatedArea)
        {
            try
            {
                if (id != updatedArea.Id)
                {
                    return BadRequest();
                }
                var context = new AcademiaContext();
                var area = await context.Areas.FindAsync(id);
                if (area == null)
                {
                    return NotFound();
                }
                //prop by prop        
                area.Description = updatedArea.Description;
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

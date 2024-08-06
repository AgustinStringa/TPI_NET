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
        public List<Area> GetAll()
        {
            var context = new AcademiaContext();
            return context.Areas.Include(a => a.Curriculums).ToList();
        }

        [HttpGet("{id}")]
        public Area GetById(int id)
        {
            var context = new AcademiaContext();
            var area = context.Areas.Find(id);
            if (area != null)
            {
                return area;
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<Area> Create(Area newArea)
        {
            var context = new AcademiaContext();
            context.Areas.Add(newArea);
            await context.SaveChangesAsync();
            return newArea;
        }

        [HttpDelete("{id}")]
        public async Task<Area> Delete(int id)
        {
            var context = new AcademiaContext();
            var deletedArea = context.Areas.Find(id);
            if (deletedArea != null)
            {
                context.Areas.Remove(deletedArea);
                await context.SaveChangesAsync();

            }
            return deletedArea;

        }

        [HttpPut("{id}")]
        public async Task<Area> Update(int id, Area updatedArea)
        {
            if (id != updatedArea.Id)
            {
                //return BadRequest();
                return null;
            }
            var context = new AcademiaContext();
            var area = await context.Areas.FindAsync(id);
            if (area == null)
            {
                //return NotFound();
                return null;
            }
            //prop by prop        
            area.Description = updatedArea.Description;
            await context.SaveChangesAsync();
            return area;
        }
    }
}

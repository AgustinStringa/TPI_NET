using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/curriculums")]

    [ApiController]
    public class CurriculumController
    {
        [HttpGet]
        public List<Curriculum> GetCurriculums()
        {
            var context = new AcademiaContext();
            return context.Curriculums.Include(c => c.Area).ToList();
        }
    }
}

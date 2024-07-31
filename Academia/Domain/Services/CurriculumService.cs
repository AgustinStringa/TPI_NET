using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Services
{
    public class CurriculumService
    {
        public IEnumerable<Curriculum> GetAll()
        {
            var context = new AcademiaContext();
            return context.Curriculums.Include(c => c.Area).ToList();
        }
    }
}

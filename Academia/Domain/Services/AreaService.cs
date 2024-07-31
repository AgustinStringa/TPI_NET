using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AreaService
    {
        public IEnumerable<Area> GetAll()
        {
            var context = new AcademiaContext();
            return context.Areas.Include(a => a.Curriculums).ToList();
        }


        public Area GetById(int Id)
        {
            var context = new AcademiaContext();
            var area = context.Areas.Find(Id);
            return area;
        }
    }
}

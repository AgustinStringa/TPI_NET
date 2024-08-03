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

        public int Delete(int Id)
        {
            var context = new AcademiaContext();
            var area = context.Areas.Find(Id);
            if(area != null) {
                 context.Areas.Remove(area);
                int rowsAffected = context.SaveChanges();
                return rowsAffected;
            } else {
            return 0;
            
            }
        }

        public void Create(Area area)
        {
            var context = new AcademiaContext();
            context.Areas.Add(area);
            context.SaveChanges();

        }

        public int Update(Area updatedArea)
        {
            var context = new AcademiaContext();
            try { 
                context.Areas.Update(updatedArea);
                int rowsAffected = context.SaveChanges();
                return rowsAffected;
            
            } catch (Exception ex)
            {
                return 0;
                throw ex;
            }

        }
    }
}

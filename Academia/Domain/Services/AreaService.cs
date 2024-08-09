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
            try
            {
                var context = new AcademiaContext();
                return context.Areas.Include(a => a.Curriculums).ToList();
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }
        public void Create(Area area)
        {
            try
            {
                var context = new AcademiaContext();
                context.Areas.Add(area);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Area area)
        {
            var context = new AcademiaContext();
            try
            {
                context.Areas.Update(area);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void Delete(int Id)
        {
            try
            {
                var context = new AcademiaContext();
                var area = context.Areas.Find(Id);
                if (area != null)
                {
                    context.Areas.Remove(area);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public Area GetById(int Id)
        {
            try
            {
                var context = new AcademiaContext();
                var area = context.Areas.Find(Id);
                return area;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }

        }
    }
}

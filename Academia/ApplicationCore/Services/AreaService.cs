using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class AreaService
    {
        public async Task<IEnumerable<Area>> GetAll()
        {
            try
            {
                var context = new AcademiaContext();
                return await context.Areas.OrderBy(a => a.Description).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task Create(Area area)
        {
            try
            {
                var context = new AcademiaContext();
                await context.Areas.AddAsync(area);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Update(Area area)
        {
            var context = new AcademiaContext();
            try
            {
                context.Areas.Update(area);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task Delete(int Id)
        {
            try
            {
                var context = new AcademiaContext();
                var area = await context.Areas.FindAsync(Id);
                if (area != null)
                {
                    context.Areas.Remove(area);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public async Task<Area> GetById(int Id)
        {
            try
            {
                var context = new AcademiaContext();
                var area = await context.Areas.FindAsync(Id);
                return area;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}

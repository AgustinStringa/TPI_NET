using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Model;

namespace ApplicationCore.Services
{
    public class CommissionService
    {
        public async Task<IEnumerable<Commission>> GetAll()
        {
            try
            {
                var context = new AcademiaContext();
                return await context.Commissions.Include(c => c.Curriculum).OrderBy(c => c.IdCurriculum).ThenBy(c => c.Level).ThenBy(c => c.Description).ToListAsync();
            }
            catch (Exception e) 
            {
                return null;
                throw e;
            }
        }

        public async Task Create(Commission commission)
        {
            try
            {
                var context = new AcademiaContext();
                await context.Commissions.AddAsync(commission);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Update(Commission commission)
        {
            var context = new AcademiaContext();
            try
            {
                context.Commissions.Update(commission);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var context = new AcademiaContext();
                var commission = await context.Commissions.FindAsync(id);
                if (commission != null)
                {
                    context.Commissions.Remove(commission);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Commission> GetById(int id)
        {
            try
            {
                var context = new AcademiaContext();
                var commission = await context.Commissions.FindAsync(id);
                return commission;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

		public async Task<IEnumerable<Commission>> GetByCurriculumIdAndLevel(int id, int level)
		{
			try
			{
				var context = new AcademiaContext();
				return await context.Commissions.Where(c => c.IdCurriculum == id && c.Level == level).ToListAsync();
			}
			catch (Exception e)
			{
				throw e;
				return null;
			}
		}
	}
}

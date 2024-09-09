using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Domain.Services
{
    public class CommissionService
    {
        public async Task<IEnumerable<Commission>> GetAll()
        {
            try
            {
                var context = new AcademiaContext();
                return await context.Commissions.Include(c => c.Curriculum).ToListAsync();
            }
            catch (Exception e) 
            {
                return null;
                throw e;
            }
        }

        public void Create(Commission commission)
        {
            try
            {
                var context = new AcademiaContext();
                context.Commissions.Add(commission);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Commission commission)
        {
            var context = new AcademiaContext();
            try
            {
                context.Commissions.Update(commission);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var context = new AcademiaContext();
                var commission = context.Commissions.Find(id);
                if (commission != null)
                {
                    context.Commissions.Remove(commission);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Commission GetById(int id)
        {
            try
            {
                var context = new AcademiaContext();
                var commission = context.Commissions.Find(id);
                return commission;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }
    }
}

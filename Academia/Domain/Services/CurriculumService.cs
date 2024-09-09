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
        public async Task<IEnumerable<Curriculum>> GetAll()
        {
            try
            {
                var context = new AcademiaContext();
                return await context.Curriculums.Include(c => c.Area).ToListAsync();
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        public async Task Create(Curriculum curriculum)
        {
            try
            {
                var context = new AcademiaContext();
                await context.Curriculums.AddAsync(curriculum);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task Update(Curriculum curriculum)
        {
            try
            {
                var context = new AcademiaContext();
                var existingCurriculum = await context.Curriculums.FindAsync(curriculum.Id);
                if (existingCurriculum != null)
                {
                    context.Entry(existingCurriculum).CurrentValues.SetValues(curriculum);
                    await context.SaveChangesAsync();
                }
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
                var curriculum = await context.Curriculums.FindAsync(id);
                if (curriculum != null)
                {
                    context.Curriculums.Remove(curriculum);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

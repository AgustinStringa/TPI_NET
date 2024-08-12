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
            try
            {
                var context = new AcademiaContext();
                return context.Curriculums.Include(c => c.Area).ToList();
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        public void Create(Curriculum curriculum)
        {
            try
            {
                var context = new AcademiaContext();
                context.Curriculums.Add(curriculum);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Update(Curriculum curriculum)
        {
            try
            {
                var context = new AcademiaContext();
                var existingCurriculum = context.Curriculums.Find(curriculum.Id);
                if (existingCurriculum != null)
                {
                    context.Entry(existingCurriculum).CurrentValues.SetValues(curriculum);
                    context.SaveChanges();
                }
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
                var curriculum = context.Curriculums.Find(id);
                if (curriculum != null)
                {
                    context.Curriculums.Remove(curriculum);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.Data.SqlClient;

namespace Domain.Services
{
    public class SubjectService
    {
        public SubjectService() { }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            var context = new AcademiaContext();
            var subjects = await context.Subjects.Include(s => s.Curriculum).OrderBy(s => s.IdCurriculum).ThenBy(c => c.Level).ToListAsync();
            foreach (var subject in subjects)
            {
                await context.Entry(subject).Collection(c => c.CorrelativesParents).LoadAsync();
                await context.Entry(subject).Collection(c => c.CorrelativesChildren).LoadAsync();
            }
            return subjects;
        }

        public async Task Create(Subject subject)
        {
            try
            {
                var context = new AcademiaContext();
                await context.Subjects.AddAsync(subject);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Update(Subject subject)
        {
            try
            {
                var context = new AcademiaContext();
                var existingSubject = await context.Subjects.FindAsync(subject.Id);
                if (existingSubject != null)
                {
                    context.Entry(existingSubject).CurrentValues.SetValues(subject);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task Delete(int Id)
        {
            try
            {
                var context = new AcademiaContext();
                var subject = context.Subjects.Find(Id);
                if (subject != null)
                {
                    context.Subjects.Remove(subject);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Subject>> GetPossibleChildrenCorrelatives(Subject subject)
        {
            try
            {
                var context = new AcademiaContext();
                var subjectIdParameter = new SqlParameter("@id_materia", subject.Id);
                var subjects = await context.Subjects.FromSqlRaw<Subject>("GetPossibleChildrenCorrelatives @id_materia", subjectIdParameter).ToListAsync();
                return subjects;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Subject>> GetPossibleParentCorrelatives(Subject subject)
        {
            try
            {
                var context = new AcademiaContext();
                var subjectIdParameter = new SqlParameter("@id_materia", subject.Id);
                var subjects = await context.Subjects.FromSqlRaw<Subject>("GetPossibleParentCorrelatives @id_materia", subjectIdParameter).ToListAsync();
                return subjects;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

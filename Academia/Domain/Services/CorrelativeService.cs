using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CorrelativeService
    {
        public async Task<Correlative> Create(Correlative correlative)
        {
            try
            {
                var context = new AcademiaContext();
                await context.Correlatives.AddAsync(correlative);
                await context.SaveChangesAsync();
                await context.Entry(correlative).Reference(c => c.Subject).LoadAsync();
                await context.Entry(correlative).Reference(c => c.CorrelativeSubject).LoadAsync();
                return correlative;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(Correlative correlative)
        {
            try
            {
                try
                {
                    var context = new AcademiaContext();
                    var corelative = await context.Correlatives.FindAsync(correlative.SubjectId, correlative.CorrelativeId);
                    if (corelative != null)
                    {
                        context.Correlatives.Remove(corelative);
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Domain.Model.Correlative>> GetCorrelativesByLevel(int subjectId, int level, CorrelativeType type)
        {
            try
            {
                var context = new AcademiaContext();


                var subjectIdParameter = new SqlParameter("@subjectId", subjectId);
                var levelParameter = new SqlParameter("@level", level);
                var typeParameter = new SqlParameter("@type", type.ToString());


                var query = @"SELECT * FROM Correlatives 
                      WHERE SubjectId = @subjectId 
                      AND Level = @level 
                      AND CorrelativeType = @type";

                var correlatives = await context.Correlatives
                    .FromSqlRaw(query, subjectIdParameter, levelParameter, typeParameter)
                    .ToListAsync();

                return correlatives;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener correlativas por nivel: " + ex.Message);
            }
        }
    }
}

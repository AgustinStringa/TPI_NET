using Domain.Model;
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

        public async void Delete(Correlative correlative)
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
    }
}

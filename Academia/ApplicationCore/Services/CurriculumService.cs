using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationCore.Services
{
	public class CurriculumService
	{
		public async Task<IEnumerable<Curriculum>> GetAll()
		{
			try
			{
				var context = new AcademiaContext();
				await context.Curriculums.Include(c => c.Area).ToListAsync();
				return await context.Curriculums.Include(c => c.Subjects).ToListAsync();
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
				if (curriculum.Area == null)
				{
					curriculum.Area = await context.Areas.FindAsync(curriculum.AreaId);
				}
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
					await context.Entry(existingCurriculum).Collection(c => c.Subjects).LoadAsync();
					if (existingCurriculum.Subjects.Count > 0)
					{
						//no se puede modificar la especialidad de un plan con materias asociadas
						throw new Exception();
					}
					if (curriculum.Area == null)
					{
						curriculum.Area = await context.Areas.FindAsync(curriculum.AreaId);
					}
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
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<Curriculum>> GetByAreaId(int id)
		{
			try
			{
				var context = new AcademiaContext();
				return await context.Curriculums.Where(c => c.AreaId == id).ToListAsync();
			}
			catch (Exception e)
			{
				throw e;
				return null;
			}
		}

		public async Task<Curriculum> GetById(int id)
		{
			try
			{
				var context = new AcademiaContext();
				var curriculum = await context.Curriculums.FindAsync(id);
				if (curriculum != null)
				{
					await context.Entry(curriculum).Reference(c => c.Area).LoadAsync();
					return curriculum;
				}
				return null;
			}
			catch (Exception e)
			{
				throw e;
			}
		}


	}
}

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
	public class CurriculumRequestParamsPopulate
	{
		public bool area { get; set; }
		public bool students { get; set; }
		public bool subjectsCount { get; set; }
		public bool commissionsCount { get; set; }
	}

	public class CurriculumRequestParams
	{
		public CurriculumRequestParamsPopulate Populate { get; set; }

		public int? AreaId { get; set; }
	}
	public class CurriculumService
	{
		public async Task<IEnumerable<Curriculum>> GetAll(CurriculumRequestParams parameters)
		{
			try
			{
				var context = new AcademiaContext();
				var curriculums = await context.Curriculums.Include(c => c.Area).Include(c => c.Subjects).ToListAsync();
				var filteredCurriculums = await context.Curriculums.Select(c => new Curriculum
				{
					Id = c.Id,
					Description = c.Description,
					Resolution = c.Resolution,
					Year = c.Year,
					AreaId = c.AreaId,
					Area = parameters.Populate.area ? new Area { Id = c.Area.Id, Description = c.Area.Description } : null,
					SubjectsCount = (parameters.Populate.subjectsCount ? c.Subjects.Count : null),
					CommissionsCount = (parameters.Populate.commissionsCount ? c.Commissions.Count : null)
				}).ToListAsync();

				if (parameters.AreaId != null)
				{
					filteredCurriculums = filteredCurriculums.Where(c => c.AreaId == parameters.AreaId).ToList();
				}
				return filteredCurriculums.OrderBy(c => c.AreaId).ToList();

			}
			catch (Exception e)
			{
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
					if (curriculum.AreaId != existingCurriculum.AreaId && existingCurriculum.Subjects.Count > 0)
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

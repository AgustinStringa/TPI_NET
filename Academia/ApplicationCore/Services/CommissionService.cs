using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Model;

namespace ApplicationCore.Services
{
	public class CommissionRequestParamsPopulate
	{
		public bool curriculum { get; set; }

	}
	public class CommissionRequestParams
	{
		public CommissionRequestParamsPopulate Populate { get; set; }
		public bool coursesCount { get; set; }
		public int? curriculumId { get; set; }
		public int? level { get; set; }
	}
	public class CommissionService
	{
		public async Task<IEnumerable<Commission>> GetAll(CommissionRequestParams parameters)
		{
			try
			{
				var context = new AcademiaContext();
				var commissions = await context.Commissions.Include(c => c.Courses).Include(c => c.Curriculum).OrderBy(c => c.IdCurriculum).ThenBy(c => c.Level).ThenBy(c => c.Description).ToListAsync();
				commissions = commissions.Select(c => new Commission
				{
					Id = c.Id,
					Description = c.Description,
					Level = c.Level,
					IdCurriculum = c.IdCurriculum,
					Curriculum = (parameters.Populate.curriculum ? new Curriculum
					{
						Id = c.Curriculum.Id,
						Description = c.Curriculum.Description,
						Year = c.Curriculum.Year,
						Resolution = c.Curriculum.Resolution,
						AreaId = c.Curriculum.AreaId
					} : null),
					CoursesCount = parameters.coursesCount ? c.Courses.Count : null
				}).ToList();

				if (parameters.curriculumId != null)
				{
					commissions = commissions.Where(c => c.IdCurriculum == parameters.curriculumId).ToList();
				}
				if (parameters.level != null)
				{
					commissions = commissions.Where(c => c.Level == parameters.level).ToList();
				}
				return commissions;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public async Task Create(Commission commission)
		{
			try
			{
				var context = new AcademiaContext();
				var curriculum = await context.Curriculums.FindAsync(commission.IdCurriculum);
				commission.Curriculum = curriculum;
				await context.Commissions.AddAsync(commission);
				await context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				if (e.InnerException != null)
				{
					throw e.InnerException;
				}
				throw e;
			}
		}

		public async Task Update(Commission commission)
		{
			try
			{
				var context = new AcademiaContext();
				var existingCommission = await context.Commissions.FindAsync(commission.Id);
				if (existingCommission != null)
				{
					await context.Entry(existingCommission).Collection(c => c.Courses).LoadAsync();
					if (commission.IdCurriculum != existingCommission.IdCurriculum && existingCommission.Courses.Count > 0)
					{
						throw new Exception("No se puedes modificar el plan de estudios de una materia con cursos asociados");
					}
					if (commission.Level != existingCommission.Level && existingCommission.Courses.Count > 0)
					{
						throw new Exception("No se puedes modificar el nivel de una materia con cursos asociados");
					}
					if (commission.Curriculum == null)
					{
						commission.Curriculum = await context.Curriculums.FindAsync(commission.IdCurriculum);
					}
					context.Entry(existingCommission).CurrentValues.SetValues(commission);
					context.Commissions.Update(existingCommission);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				if (e.InnerException != null)
				{
					throw e.InnerException;
				}
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
				if (e.InnerException as Microsoft.Data.SqlClient.SqlException != null)
				{

					if (((Microsoft.Data.SqlClient.SqlException)e.InnerException).ErrorCode == -2146232060)
					{

						throw new Exception("No puedes eliminar una comisión con cursos asignados");
					};
				}
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
			}
		}
	}
}

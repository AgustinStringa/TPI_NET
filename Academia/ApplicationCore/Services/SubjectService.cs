using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Model;
using Microsoft.Data.SqlClient;

namespace ApplicationCore.Services
{
	public class SubjectRequestParams
	{
		public bool curriculum { get; set; }
		public bool coursesCount { get; set; }
	}
	public class SubjectService
	{
		public SubjectService() { }

		public async Task<IEnumerable<Subject>> GetAll(SubjectRequestParams parameters)
		{
			var context = new AcademiaContext();
			var subjects = await context.Subjects.Include(s => s.Curriculum).OrderBy(s => s.IdCurriculum).ThenBy(c => c.Level).ToListAsync();
			subjects = subjects.Select(
				s =>
				new Subject
				{
					Id = s.Id,
					Description = s.Description,
					WeeklyHours = s.WeeklyHours,
					TotalHours = s.TotalHours,
					Level = s.Level,
					IdCurriculum = s.IdCurriculum,
					Curriculum = parameters.curriculum ? new Curriculum { Id = s.Curriculum.Id, Description = s.Curriculum.Description, AreaId =s.Curriculum.AreaId } : null,
					CoursesCount = parameters.coursesCount ? s.Courses.Count : null,
				}
				).ToList();
			return subjects;
		}

		public async Task Create(Subject subject)
		{
			try
			{
				var context = new AcademiaContext();
				if (subject.Curriculum == null)
				{
					subject.Curriculum = await context.Curriculums.FindAsync(subject.IdCurriculum);
				}
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
					await context.Entry(existingSubject).Collection(c => c.Courses).LoadAsync();

					if (subject.IdCurriculum != existingSubject.IdCurriculum && existingSubject.Courses.Count > 0)
					{
						//no se puede modificar el plan de estudios de una materia con cursos
						throw new Exception();
					}
					if (existingSubject.Curriculum == null)
					{
						existingSubject.Curriculum = await context.Curriculums.FindAsync(subject.IdCurriculum);
					}
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
				var subject = await context.Subjects.FindAsync(Id);
				if (subject != null)
				{
					context.Subjects.Remove(subject);
					await context.SaveChangesAsync();
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

		public async Task<IEnumerable<Subject>> GetByCurriculumId(int id)
		{
			try
			{
				var context = new AcademiaContext();
				var subjects = await context.Subjects.Where(s => s.IdCurriculum == id).ToListAsync();
				return subjects;
			}
			catch (Exception)
			{
				throw;
			}

		}

		public async Task<Subject> GetById(int id)
		{
			try
			{
				var context = new AcademiaContext();
				var subject = await context.Subjects.FindAsync(id);
				return subject;
			}
			catch (Exception)
			{
				throw;
			}

		}
	}
}

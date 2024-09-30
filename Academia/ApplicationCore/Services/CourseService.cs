using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
namespace ApplicationCore.Services
{
	public class CourseRequestParams
	{
		public bool commission { get; set; }
		public bool subject { get; set; }
		public bool teachers { get; set; }
		public bool inscriptions { get; set; }
	}
	public class CourseService
	{
		public async Task<IEnumerable<Course>> GetAvailableCourses(User user)
		{
			var context = new AcademiaContext();
			var studentIdParameter = new SqlParameter("@id_alumno", user.Id);
			var courses = await context.Courses.FromSqlRaw<Course>("GetAvailableCourses @id_alumno", studentIdParameter).ToListAsync();
			foreach (var course in courses)
			{
				await context.Entry(course).Reference(c => c.Subject).LoadAsync();
				await context.Entry(course).Reference(c => c.Commission).LoadAsync();
			}
			return courses;
		}

		public async Task<IEnumerable<Course>> GetAll(CourseRequestParams parameters)
		{
			var context = new AcademiaContext();
			var courses = await context.Courses.Include(c => c.Subject).Include(c => c.Commission).Include(c => c.Teachers)
				.OrderBy(c => c.Subject.IdCurriculum).ThenBy(c => c.Subject.Description).ThenBy(c => c.Commission.Description)
				.ToListAsync();
			foreach (var course in courses)
			{
				await context.Entry(course.Subject).Reference(s => s.Curriculum).LoadAsync();
			}
			courses = courses.Select(c =>
			new Course
			{
				Id = c.Id,
				CalendarYear = c.CalendarYear,
				Capacity = c.Capacity,
				IdSubject = c.IdSubject,
				Subject = parameters.subject ? new Subject
				{
					Id = c.Subject.Id,
					Description = c.Subject.Description,
					IdCurriculum = c.Subject.IdCurriculum,
					Curriculum = new Curriculum { Description = c.Subject.Curriculum.Description, AreaId = c.Subject.Curriculum.AreaId},
					Courses = new List<Course>()

				} : null,
				IdCommission = c.IdCommission,
				Commission = parameters.commission ? new Commission
				{
					Id = c.Commission.Id,
					Description = c.Commission.Description,
					Level = c.Commission.Level,
					IdCurriculum = c.Commission.IdCurriculum,
					Curriculum = null,
					Courses = new List<Course>(),
				} : null,
				Teachers = parameters.teachers ? c.Teachers : null
			}
			).ToList();
			return courses;
		}

		public async Task<Course> GetById(int id)
		{
			var context = new AcademiaContext();
			var course = await context.Courses.FindAsync(id);
			if (course != null)
			{
				await context.Entry(course).Reference(c => c.Commission).LoadAsync();
			}
			return course;
		}

		public async Task Update(Course course)
		{
			try
			{
				var context = new AcademiaContext();

				var existingCourse = await context.Courses
				.Include(c => c.Teachers)
				.Include(c => c.Commission)
				.Include(c => c.UserCourses)
				.FirstOrDefaultAsync(c => c.Id == course.Id);

				if (existingCourse != null)
				{
					//que pasa con actualizar
					//inscripciones
					existingCourse.CalendarYear = course.CalendarYear;
					existingCourse.Capacity = course.Capacity;

					var updateSubject = (course.IdSubject != existingCourse.IdSubject);
					var updateCommission = (course.IdCommission != existingCourse.IdCommission);
					if (
						(existingCourse.UserCourses.Count > 0 && updateCommission)
						||
						(existingCourse.UserCourses.Count > 0 && updateSubject)
						)
					{
						throw new Exception();
					}

					if (course.Teachers.Count > 0)
					{
						existingCourse.Teachers.Clear();

						var selectedTeacherIds = course.Teachers.Select(t => t.Id).ToList();
						var newTeachers = await context.Teachers
										  .Where(u => selectedTeacherIds.Contains(u.Id))
										  .ToListAsync();

						foreach (var teacher in newTeachers)
						{
							existingCourse.Teachers.Add(teacher);
						}
					}
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task Delete(int id)
		{
			try
			{
				var context = new AcademiaContext();
				var existingCourse = await context.Courses.Include(c => c.Teachers).FirstOrDefaultAsync(c => c.Id == id);
				if (existingCourse != null)
				{
					//		await context.Database.ExecuteSqlRawAsync(
					//"DELETE FROM docentes_cursos WHERE id_curso = {0}", course.Id);
					//existingCourse.Teachers.Clear();
					context.Courses.Remove(existingCourse);
					//Validate REFERENCE FK
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				//manejar eliminacion de cursado con inscripciones
				throw;
			}
		}

		public async Task Create(Course course)
		{
			try
			{
				//TO DO: validar que el plan de estudios de la comision
				// sea igual al plan de estudios de la materia
				var context = new AcademiaContext();

				var subject = await context.Subjects.FindAsync(course.IdSubject);
				var commission = await context.Commissions.FindAsync(course.IdCommission);
				if (commission.IdCurriculum != subject.IdCurriculum)
				{
					throw new Exception();
				}
				if (course.Subject == null)
				{
					course.Subject = subject;
				}
				if (course.Commission == null)
				{
					course.Commission = commission;
				}
				if (course.Teachers.Count > 0)
				{
					var selectedTeacherIds = course.Teachers.Select(t => t.Id).ToList();
					var existingTeachers = await context.Teachers
										  .Where(u => selectedTeacherIds.Contains(u.Id))
										  .ToListAsync();
					course.Teachers = existingTeachers;
				}
				await context.Courses.AddAsync(course);
				await context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw;
			}
		}
	}
}

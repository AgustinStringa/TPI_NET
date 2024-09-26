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
			}
			return courses;
		}

		public async Task<IEnumerable<Course>> GetAll()
		{
			var context = new AcademiaContext();
			var courses = await context.Courses.Include(c => c.Subject).Include(c => c.Commission).Include(c => c.Teachers)
				.OrderBy(c => c.Subject.IdCurriculum).ThenBy(c => c.Subject.Description).ThenBy(c => c.Commission.Description)
				.ToListAsync();
			foreach (var course in courses)
			{
				await context.Entry(course.Subject).Reference(s => s.Curriculum).LoadAsync();
			}
			return courses;
		}

		public void Create(Course course)
		{
			try
			{
				var context = new AcademiaContext();
				context.Courses.Add(course);
				context.SaveChanges();
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task Update(Course course)
		{
			try
			{
				var context = new AcademiaContext();

				var existingCourse = await context.Courses
				.Include(c => c.Teachers) 
				.FirstOrDefaultAsync(c => c.Id == course.Id);

				if (existingCourse != null)
				{

					context.Entry(existingCourse).CurrentValues.SetValues(course);

					if (course.Teachers.Count > 0)
					{
						existingCourse.Teachers.Clear();

						var selectedTeacherIds = course.Teachers.Select(t => t.Id).ToList();
						var newTeachers = await context.Users
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

		public async Task Delete(Course course)
		{
			try
			{
				var context = new AcademiaContext();
				var existingCourse = await context.Courses.Include(c => c.Teachers).FirstOrDefaultAsync(c => c.Id == course.Id);
				if (existingCourse != null)
				{
					await context.Database.ExecuteSqlRawAsync(
			"DELETE FROM docentes_cursos WHERE id_curso = {0}", course.Id);
					existingCourse.Teachers.Clear();
					context.Courses.Remove(existingCourse);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task Add(Course course)
		{
			try
			{
				var context = new AcademiaContext();
				if (course.Teachers.Count > 0)
				{
					var selectedTeacherIds = course.Teachers.Select(t => t.Id).ToList();
					var existingTeachers = await context.Users
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

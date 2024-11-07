using ApplicationCore.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class StudentCourseService
	{


		public async Task Delete(int userCourseId)
		{
			try
			{
				using (var context = new AcademiaContext())
				{
					var userCourse = await context.UserCourses.FindAsync(userCourseId);

					if (userCourse == null)
					{
						throw new InvalidOperationException("No se encontró la inscripción del usuario en el curso especificado.");
					}
					//TODO: validar que el usuario sea el propietario del cursado a eliminar
					context.UserCourses.Remove(userCourse);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				throw new Exception("Ocurrió un error al eliminar la inscripción del usuario en el curso.", e);
			}
		}

		public async Task Create(StudentCourse userCourse)
		{
			try
			{
				using (var context = new AcademiaContext())
				{

					userCourse.Course = await context.Courses.FirstOrDefaultAsync(c => c.Id == userCourse.CourseId);

					if (await IsUserAlreadyEnrolled(userCourse.UserId, userCourse.CourseId, userCourse.Course.CalendarYear))
					{
						throw new InvalidOperationException("El usuario ya está inscrito en este curso bajo las condiciones especificadas.");
					}

					await context.UserCourses.AddAsync(userCourse);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				throw new Exception("Ocurrió un error al inscribir al usuario en el curso.", e);
			}
		}


		public async Task<bool> IsUserAlreadyEnrolled(int userId, int courseId, string calendarYear)
		{
			using (var context = new AcademiaContext())
			{
				var previousEnrollments = await context.UserCourses
					.Where(uc => uc.UserId == userId && uc.CourseId == courseId)
					.ToListAsync();

				if (!previousEnrollments.Any())
				{
					return false;
				}

				var hasFreeEnrollmentWithDifferentYear = previousEnrollments.Any(uc =>
					uc.Status == "libre" && uc.Course.CalendarYear != calendarYear);

				return !hasFreeEnrollmentWithDifferentYear;
			}
		}

		public async Task<IEnumerable<StudentCourse>> GetByUserId(int id, bool actives)
		{

			try
			{
				var context = new AcademiaContext();
				var userCourses = await context.UserCourses.Include(uc => uc.Course).Where(uc => uc.UserId == id && (actives ? uc.Grade == null : uc.Grade != null)).ToListAsync();
				//Se podria resolver en la DB tamb?
				foreach (var userCourse in userCourses)
				{
					var course = userCourse.Course;
					await context.Entry(course).Reference(c => c.Subject).LoadAsync();
					await context.Entry(course).Reference(c => c.Commission).LoadAsync();
				}
				return userCourses.OrderBy(uc => uc.Course.Subject.Level).ToList();

			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<StudentCourse> GetById(int id)
		{

			try
			{
				var context = new AcademiaContext();
				var userCourses = await context.UserCourses.FindAsync(id);
				return userCourses;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<StudentCourse> QualifyCourse(int id, CalificationCourse calification)
		{

			try
			{
				var context = new AcademiaContext();
				var userCourse = await context.UserCourses.FindAsync(id);
				if (userCourse == null)
				{
					throw new Exception();
				}
				userCourse.Status = calification.Status;
				userCourse.Grade = calification.Grade;
				await context.SaveChangesAsync();
				return userCourse;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<AcademicStatusItem>> GetAcademicStatus(int studentId)
		{
			try
			{
				var context = new AcademiaContext();
				var studentIdParameter = new SqlParameter("@id_estudiante", studentId);
				var courses =  await context.Set<AcademicStatusItem>().FromSqlRaw("EXEC getEstadoAcademico @id_estudiante", studentIdParameter).ToListAsync();
				return courses;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
	public class CalificationCourse
	{
		public string Status { get; set; }
		public decimal Grade { get; set; }
	}

	public class AcademicStatusItem
	{
		[Column("desc_materia")]
		public string SubjectDescription { get; set; }
		
		[Column("condicion")]
		public string Condition { get; set; }

		[Column("nota")]
		public decimal Grade { get; set; }

		[Column("anio_calendario")]
		public string CalendarYear { get; set; }

		[Column("nivel_materia")]
		public int SubjectLevel { get; set; }
	}
}

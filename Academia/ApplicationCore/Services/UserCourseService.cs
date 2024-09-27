using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class UserCourseService
	{

		public async Task Update(UserCourse userCourse)
		{
			try
			{
				using (var context = new AcademiaContext())
				{
					context.UserCourses.Update(userCourse);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				throw new Exception("Ocurrió un error al actualizar la inscripción del usuario en el curso.", e);
			}
		}

		public async Task Delete(int userId, int courseId)
		{
			try
			{
				using (var context = new AcademiaContext())
				{
					var userCourse = await context.UserCourses.FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CourseId == courseId);

					if (userCourse == null)
					{
						throw new InvalidOperationException("No se encontró la inscripción del usuario en el curso especificado.");
					}

					context.UserCourses.Remove(userCourse);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				throw new Exception("Ocurrió un error al eliminar la inscripción del usuario en el curso.", e);
			}
		}

		public async Task Add(UserCourse userCourse)
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

		public async Task<IEnumerable<UserCourse>> GetUserCoursesByUserId(int id)
		{

			try
			{
				var context = new AcademiaContext();
				var userCourses = await context.UserCourses.Include(uc => uc.Course).Where(uc => uc.UserId == id).ToListAsync();
				foreach (var userCourse in userCourses)
				{
					var course = userCourse.Course;
					await context.Entry(course).Reference(c => c.Subject).LoadAsync();
					await context.Entry(course).Reference(c => c.Commission).LoadAsync();
				}
				return userCourses;

			}
			catch (Exception)
			{
				throw;
			}
		}






	}
}

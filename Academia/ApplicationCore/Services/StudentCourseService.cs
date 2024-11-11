using ApplicationCore.Model;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Html2pdf;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class StudentCourseService
	{


		public async Task Delete(int studentCourseId)
		{
			try
			{
				using (var context = new AcademiaContext())
				{
					var studentCourse = await context.StudentCourses.FindAsync(studentCourseId);

					if (studentCourse == null)
					{
						throw new InvalidOperationException("No se encontró la inscripción del usuario en el curso especificado.");
					}
					//TODO: validar que el usuario sea el propietario del cursado a eliminar
					context.StudentCourses.Remove(studentCourse);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				throw new Exception("Ocurrió un error al eliminar la inscripción del usuario en el curso.", e);
			}
		}

		public async Task Create(StudentCourse studentCourse)
		{
			try
			{
				using (var context = new AcademiaContext())
				{

					studentCourse.Course = await context.Courses.FirstOrDefaultAsync(c => c.Id == studentCourse.CourseId);

					if (await IsUserAlreadyEnrolled(studentCourse.UserId, studentCourse.CourseId, studentCourse.Course.CalendarYear))
					{
						throw new InvalidOperationException("El usuario ya está inscrito en este curso bajo las condiciones especificadas.");
					}

					await context.StudentCourses.AddAsync(studentCourse);
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
				var previousEnrollments = await context.StudentCourses
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
				var studentCourses = await context.StudentCourses.Include(uc => uc.Course).Where(uc => uc.UserId == id && (actives ? uc.Grade == null : uc.Grade != null)).ToListAsync();
				//Se podria resolver en la DB tamb?
				foreach (var userCourse in studentCourses)
				{
					var course = userCourse.Course;
					await context.Entry(course).Reference(c => c.Subject).LoadAsync();
					await context.Entry(course).Reference(c => c.Commission).LoadAsync();
				}
				return studentCourses.OrderBy(uc => uc.Course.Subject.Level).ToList();

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
				var studentCourses = await context.StudentCourses.FindAsync(id);
				return studentCourses;
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
				var studentCourse = await context.StudentCourses.FindAsync(id);
				if (studentCourse == null)
				{
					throw new Exception();
				}
				studentCourse.Status = calification.Status;
				studentCourse.Grade = calification.Grade;
				await context.SaveChangesAsync();
				return studentCourse;
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
				var courses = await context.Set<AcademicStatusItem>().FromSqlRaw("EXEC getEstadoAcademico @id_estudiante", studentIdParameter).ToListAsync();
				return courses;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<byte[]> GetAcademicStatusReport(int studentId)
		{
			try
			{
				var context = new AcademiaContext();
				var student = await context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
				var studentIdParameter = new SqlParameter("@id_estudiante", studentId);
				IEnumerable<AcademicStatusItem> academicStatus = await context.Set<AcademicStatusItem>().FromSqlRaw("EXEC getEstadoAcademico @id_estudiante", studentIdParameter).ToListAsync();

				using (MemoryStream memoryStream = new MemoryStream())
				{

					int totalSubjects = academicStatus.Count();

					int passedSubjects = 0, failedSubjects = 0;
					double passedSubjectPerc = 0, failedSubjectPerc = 0, average = 0;
					if (totalSubjects != 0)
					{
						passedSubjects = academicStatus.Count(item => item.Grade >= 6);
						failedSubjects = academicStatus.Count(item => item.Grade < 6);
						passedSubjectPerc = passedSubjects * 100 / totalSubjects;
						failedSubjectPerc = failedSubjects * 100 / totalSubjects;
						average = Math.Round(((double)academicStatus.Sum(i => i.Grade)) / totalSubjects,2);

					}



					PdfWriter writer = new PdfWriter(memoryStream);
					PdfDocument pdf = new PdfDocument(writer);
					iText.Layout.Document document = new(pdf);
					string rowsContent = "";

					if (academicStatus.Count() <= 0)
					{
						rowsContent = "El estudiante no cuenta con materias rendidas";
					}
					else
					{

						foreach (AcademicStatusItem item in academicStatus)
						{
							rowsContent +=
									"<tr>" +
										"<td>" +
										item.SubjectDescription +
										"</td>" +

										"<td>" +
										item.Condition +
										"</td>" +

										"<td>" +
										item.Grade.ToString() +
										"</td>" +

										"<td>" +
										item.CalendarYear +
										"</td>" +

										"<td>" +
										item.SubjectLevel +
										"</td>" +
									"</tr>";
						}
					}
					string htmlContent =
						"<html>" +
						"<head>" +
						"<style>" +
						" * {font-family: sans-serif;}" +

						"table {border-collapse: collapse;border: 1px solid #dee2e6;}" +

						"th {font-weight: bold;}" +

						"td {font-weight: normal;}" +

						"th,td {padding: 20px;border: 1px solid gray;}" +

						"</style>" +
						"</head>" +
						"<body>" +

						"<div>" +
						"<h1>Estado Academico</h1>" +
						$"<h2>Alumno: {student.Name} {student.Lastname} al {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} </h2>" +
						$"<p>Legajo: {student.StudentId.Trim()}</p>" +
						"<table>" +
						"<thead>" +
						   "<tr>" +
							   "<th>" +
							   "Materia" +
							   "</th>" +

							   "<th>" +
							   "Estado" +
							   "</th>" +

							   "<th>" +
							   "Nota" +
							   "</th>" +

							   "<th>" +
							   "Año Calendario" +
							   "</th>" +

							   "<th>" +
							   "Nivel" +
							   "</th>" +

						   "" +
						   "</tr>" +
						"" +
						"</thead>" +
						"<tbody>" +
						   rowsContent +
						"</tbody>" +
						"" +
						"</table>" +
						"<div>" +


						$"<h2>promedio: {average.ToString()}</h2>" +
						$"<p>porcentaje materias aprobadas: {passedSubjectPerc.ToString()} % ({passedSubjects})</p>" +
						$"<p>porcentaje materias reprobadas: {failedSubjectPerc.ToString()} % ({failedSubjects})</p>" +

						"</body>" +

						"</html>"
					;
					HtmlConverter.ConvertToPdf(htmlContent, writer);

					return memoryStream.ToArray();
				}
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

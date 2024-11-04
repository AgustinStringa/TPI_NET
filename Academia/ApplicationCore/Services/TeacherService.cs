using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class TeacherService
	{
		public async Task<IEnumerable<ApplicationCore.Model.Teacher>> GetAll()
		{
			var context = new AcademiaContext();
			return await context.Teachers.ToListAsync();
		}

		public async Task<ApplicationCore.Model.Teacher> GetById(int id)
		{
			var context = new AcademiaContext();
			return await context.Teachers.FindAsync(id);
		}

		public async Task Create(Teacher teacher)
		{
			try
			{
				var context = new AcademiaContext();
				await context.Teachers.AddAsync(teacher);
				await context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task Update(Teacher teacher)
		{
			try
			{
				var context = new AcademiaContext();
				var existingTeacher = await context.Teachers.FindAsync(teacher.Id);

				if (existingTeacher != null)
				{
					foreach (var prop in existingTeacher.GetType().GetProperties())
					{
						if (prop.Name == "Password" && teacher.Password != null)
						{
							existingTeacher.Password = Util.EncodePassword(teacher.Password);
						}
						if (prop.Name != "TeacherCourses" && prop.Name != "TeacherId"
							&& prop.Name != "Password" && prop.Name != "Id")
						{

							prop.SetValue(existingTeacher, prop.GetValue(teacher));
						}
					}

					context.Teachers.Update(existingTeacher);
					await context.SaveChangesAsync();
				}
				else
				{
					throw new Exception("Error en las actualizacion del profesor");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}

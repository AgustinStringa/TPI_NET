using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class StudentService
	{
		public async Task<IEnumerable<ApplicationCore.Model.Student>> GetAll()
		{
			var context = new AcademiaContext();
			var students = await context.Students.Include(u => u.Curriculum).ToListAsync();
			foreach (var student in students)
			{
				var curriculum = student.Curriculum;
				await context.Entry(curriculum).Reference(c => c.Area).LoadAsync();
			}
			//utilizar select para remover datos innecesarios
			return students;
		}

		public async Task<ApplicationCore.Model.Student> GetById(int id)
		{
			var context = new AcademiaContext();
			return await context.Students.Include(u => u.Curriculum).FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task Create(Student student)
		{
			try
			{
				var context = new AcademiaContext();
				await context.Students.AddAsync(student);
				await context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

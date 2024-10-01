using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public  class TeacherService
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
	}
}

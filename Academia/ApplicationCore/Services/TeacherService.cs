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
		public async Task<IEnumerable<ApplicationCore.Model.User>> GetAll()
		{
			var context = new AcademiaContext();
			return await context.Teachers.ToListAsync();
		}

	}
}

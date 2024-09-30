using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class AdministrativeService
	{
		public async Task<IEnumerable<ApplicationCore.Model.Administrative>> GetAll()
		{
			var context = new AcademiaContext();
			return await context.Administratives.ToListAsync();
		}
		public async Task<ApplicationCore.Model.Administrative> GetById(int id)
		{
			var context = new AcademiaContext();
			return await context.Administratives.FindAsync(id);
		}
	}
}

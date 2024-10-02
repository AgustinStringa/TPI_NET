using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Teacher
{
	public interface ITeacherService
	{
		public Task CreateAsync(ApplicationCore.Model.Teacher teacher);
		public Task<ApplicationCore.Model.Teacher> GetById(int id);
		public Task<IEnumerable<ApplicationCore.Model.Teacher>> GetAllAsync();
	}
}

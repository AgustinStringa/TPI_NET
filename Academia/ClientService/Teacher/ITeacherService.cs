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
		public Task<IEnumerable<ApplicationCore.Model.Teacher>> GetAll();
		public Task<ApplicationCore.Model.Teacher> GetById(int id);
		public Task Create(ApplicationCore.Model.Teacher teacher);
		public Task Update(ApplicationCore.Model.Teacher teacher);
	}
}

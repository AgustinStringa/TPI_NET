using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Student
{
	public interface IStudentService
	{
		public Task CreateAsync(ApplicationCore.Model.Student student);
		public Task<ApplicationCore.Model.Student> GetById(int id);

		public Task<IEnumerable<ApplicationCore.Model.Student>> GetAllAsync();
	}
}

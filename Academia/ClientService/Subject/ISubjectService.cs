using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Subject
{
	public interface ISubjectService
	{
		public Task CreateAsync(ApplicationCore.Model.Subject subject);
		public Task<IEnumerable<ApplicationCore.Model.Subject>> GetAllAsync();
		public Task<IEnumerable<ApplicationCore.Model.Subject>> GetAllByCurriculumId(int id);
		public Task GetByIdAsync(int id);
		public Task DeleteAsync(int id);
		public Task UpdateAsync(ApplicationCore.Model.Subject subject);
		public Task<ApplicationCore.Model.Subject> GetByIdWithCurriculumAndCourses(int id);
		public Task<IEnumerable<ApplicationCore.Model.Subject>> GetAllWithCurriculum();
	}
}

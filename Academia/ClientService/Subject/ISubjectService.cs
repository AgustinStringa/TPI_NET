using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Subject
{
	public interface ISubjectService
	{
		public Task<IEnumerable<ApplicationCore.Model.Subject>> GetAllWithCurriculum();
		public Task<IEnumerable<ApplicationCore.Model.Subject>> GetAllByCurriculumId(int id);
		public Task<ApplicationCore.Model.Subject> GetByIdWithCurriculumAndCourses(int id);
		public Task Create(ApplicationCore.Model.Subject subject);
		public Task Update(ApplicationCore.Model.Subject subject);
		public Task Delete(int id);
	}
}

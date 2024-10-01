using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Commission
{
	public interface ICommissionService
	{
		public Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllAsync();

		public Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllByCurriculumIdAndLevel(int curriculumId, int level);
		public Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllWithCurriculum();

		public Task DeleteAsync(int id);

		public Task UpdateAsync(ApplicationCore.Model.Commission commission);

		public Task CreateAsync(ApplicationCore.Model.Commission commission);
	}
}

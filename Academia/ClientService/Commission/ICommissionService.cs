using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Commission
{
    public interface ICommissionService
    {
        public Task<IEnumerable<ApplicationCore.Model.Commission>> GetAll();
        public Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllWithCurriculum();
        public Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllByCurriculumIdAndLevel(int curriculumId, int level);
        public Task<ApplicationCore.Model.Commission> GetById(int id);
        public Task Create(ApplicationCore.Model.Commission commission);
        public Task Update(ApplicationCore.Model.Commission commission);
        public Task Delete(int id);
    }
}

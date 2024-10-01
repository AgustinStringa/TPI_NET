using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Model;

namespace ClientService.Curriculum
{
    public interface ICurriculumService
    {
        Task CreateAsync(ApplicationCore.Model.Curriculum curriculum);
        Task<IEnumerable<ApplicationCore.Model.Curriculum>> GetAllAsync();
		Task<IEnumerable<ApplicationCore.Model.Curriculum>> GetAllWithAreaAsync();
        Task<IEnumerable<ApplicationCore.Model.Curriculum>> GetAllByAreaId(int areaId);
		Task UpdateAsync(ApplicationCore.Model.Curriculum curriculum);
        Task DeleteAsync(int id);
    }
}

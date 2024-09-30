using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Model;

namespace ClientService.Area
{
    public interface IAreaService
    {
        Task CreateAsync(ApplicationCore.Model.Area area);
        Task<IEnumerable<ApplicationCore.Model.Area>> GetAllAsync();
        Task UpdateAsync(ApplicationCore.Model.Area area);
        Task DeleteAsync(int id);
    }
}

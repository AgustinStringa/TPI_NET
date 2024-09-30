using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Model;

namespace ClientService
{
    public interface IAreaService
    {
        Task CreateAsync(Area area);
        Task<IEnumerable<Area>> GetAllAsync();
        Task UpdateAsync(Area area);
        Task DeleteAsync(int id);
    }
}

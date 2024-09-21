using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace ClientService
{
    public interface ICurriculumService
    {
        Task CreateAsync(Curriculum curriculum);
        Task<IEnumerable<Curriculum>> GetAllAsync();
        Task UpdateAsync(Curriculum curriculum);
        Task DeleteAsync(int id);
    }
}

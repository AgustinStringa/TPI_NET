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
		Task<IEnumerable<ApplicationCore.Model.Area>> GetAll();
		Task<ApplicationCore.Model.Area> GetById(int id);
		Task Create(ApplicationCore.Model.Area area);
		Task Update(ApplicationCore.Model.Area area);
		Task Delete(int id);
	}
}

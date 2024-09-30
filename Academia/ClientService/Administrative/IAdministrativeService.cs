using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Administrative
{
	public interface IAdministrativeService
	{
		public Task CreateAsync(ApplicationCore.Model.Administrative administrative);
		public Task<ApplicationCore.Model.Administrative> GetById(int id);
	}
}

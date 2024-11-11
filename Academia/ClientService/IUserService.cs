using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClientService.UserService;

namespace ClientService
{
	public interface IUserService
	{
		Task<IEnumerable<ApplicationCore.Services.UserDTO>> GetAll();
		Task DeleteAsync(int id);
		Task<UserLoggedDTO> ValidateCredentials(string username, string password);
    }
}

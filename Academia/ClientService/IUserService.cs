using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
	public interface IUserService
	{
		Task CreateAsync(User user);
		Task<IEnumerable<UserDTO>> GetAllAsync();
		Task DeleteAsync(int id);
		Task<User> GetById(int id);
	}
}

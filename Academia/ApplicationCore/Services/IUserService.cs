using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Model;

namespace ApplicationCore.Services
{
    public interface IUserService
    {
        void Add(User user);
        void Update();
        User GetById();

        void Delete();
        Task<IEnumerable<User>> GetAll();
    }

}

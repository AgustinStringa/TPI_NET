using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Services
{
    public interface IUserService
    {
        void Add(User user);
        void Update();
        User GetById();

        void Delete();
        IEnumerable<User> GetAll();
    }

}

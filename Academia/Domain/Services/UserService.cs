using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        
        public void Add(User user)
        {
            var context = new AcademiaContext();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var context = new AcademiaContext();
            return context.Users.Include(u => u.CurriculumId).ToList();
        }

        public User GetById()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

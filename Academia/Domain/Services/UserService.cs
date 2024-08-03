using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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

        public bool ValidateCredentials(string username, string password)
        {

            var context = new AcademiaContext();
            Domain.Model.User user = context.Users.First(u => u.Username == username);
            byte[] sentHashValue = Convert.FromHexString(user.Password);

            byte[] messageBytes1 = Encoding.UTF8.GetBytes(password);
            byte[] compareHashValue = SHA256.HashData(messageBytes1);

            return sentHashValue.SequenceEqual(compareHashValue);
        }
    }
}

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

        public User ValidateCredentials(string username, string password)
        {

            var context = new AcademiaContext();
            Domain.Model.User user = context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null) { 
                byte[] sentHashValue = Convert.FromHexString(user.Password);
                byte[] messageBytes1 = Encoding.UTF8.GetBytes(password);
                byte[] compareHashValue = SHA256.HashData(messageBytes1);
                if (sentHashValue.SequenceEqual(compareHashValue))
                {
                    return user;
                }
                else {
                    return null;
                }

            }
            else
            {
                return null;
            }



        }
    }
}

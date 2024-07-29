
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Student : IUser
    {


        #region properties

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Authorized { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public string File { get; set; }
        #endregion

        #region constructors
        public Student(string username, string password, string email, string name, string lastname, string address, string phonenumber, DateTime birthdate, string File)
          
        {
            Username = username;
            Password = password;
            Authorized = true;
            Email = email;
            Name = name;
            LastName = lastname;
            Address = address;
            PhoneNumber = phonenumber;
            BirthDate = birthdate;
            File = File;
        }
        #endregion
    }
}

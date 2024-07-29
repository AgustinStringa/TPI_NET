using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Administrative : IUser
    {
        public int Id { get;set; }
        public string Username { get;set; }
        public string Password { get;set; }
        public bool Authorized { get;set; }
        public string Email { get;set; }
        public string Name { get;set; }
        public string LastName { get;set; }
        public string Address { get;set; }
        public string PhoneNumber { get;set; }
        public DateTime BirthDate { get;set; }

        public string Cuit { get; set; }

        #region constructors
        public Administrative(string username, string password, string email, string name, string lastname, string address, string phonenumber, DateTime birthdate, string cuit)

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
            Cuit = cuit; 
        }
        #endregion
    }
}

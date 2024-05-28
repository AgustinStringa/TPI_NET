
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Student : User
    {
        #region fields
        private string _File;
        #endregion

        #region properties
        public string File
        {
            get { return _File; }
            set { _File = value; }
        }
        #endregion

        #region constructors
        public Student(string username, string password, string email, string name, string lastname, string address, string phonenumber, DateTime birthdate, string File) 
            : base(username, password, email, name, lastname, address, phonenumber, birthdate)
        {
            _File = File;
        }
        #endregion
    }
}

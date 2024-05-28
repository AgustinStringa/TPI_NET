using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Administrative : User
    {

        #region constructors
        public Administrative(string username, string password, string email, string name, string lastname, string address, string phonenumber, DateTime birthdate, string legajo)
            : base(username, password, email, name, lastname, address, phonenumber, birthdate)
        {
           
        }
        #endregion
    }
}

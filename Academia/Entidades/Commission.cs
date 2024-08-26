using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Commission
    {
        #region fields
        private int _Id;
        private string _Description;
        private int _Year;
        #endregion

        #region properties
        public int IdCommission
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        
        #endregion

        #region constructors
        public Commission(string description, int year)
        {
            _Description = description;
            _Year = year;
        }

        public Commission(string description, int year, int id)
        {
            _Id = id;
            _Description = description;
            _Year = year;
        }
        #endregion
    }
}

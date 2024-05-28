using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Area
    {
        #region fields
        private int _IdArea;
        private string _Description;
        #endregion

        #region properties
        public int IdArea
		{
			get { return _IdArea; }
			set { _IdArea = value; }
		}

        public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}
        #endregion

        #region constructors
        public Area(string description) {
			_Description = description;
		}
        #endregion
    }
}

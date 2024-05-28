using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Curriculum
    {
        #region fields
        private int _Id;
        private string _Description;
        private Area _Area;
        #endregion


        #region properties
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public Area Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
        #endregion

        #region constructors
        public Curriculum(string description, Area area) {
            _Description = description;
            _Area = area;
        }
        #endregion




    }
}

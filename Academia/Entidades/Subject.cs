using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Subject
    {
        #region fields
        private string _Name;
        private int _WeekHours;
        private int _TotalHours;
        private int _IdPlan;
        #endregion

        #region properties
        public string Name { get { return _Name; } set { _Name = value; } }


        public int WeekHours { get { return _WeekHours; } set { _WeekHours = value; } }

        public int TotalHours { get { return _TotalHours;} set { _TotalHours = value; } }

        public int IdPlan { get { return _IdPlan;} set { _IdPlan = value; } }



        #endregion

        #region constructors

        public Subject(string name, int weekHours)

        {
            _Name = name;
            _WeekHours = weekHours;
        }

        #endregion
    }
}

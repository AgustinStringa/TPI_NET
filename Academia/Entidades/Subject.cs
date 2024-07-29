using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Subject
    {
        #region fields
        private int _Id;
        private string _Descripcion;
        private int _WeekHours;
        private int _TotalHours;
        private Curriculum _IdPlan;
        #endregion

        #region properties

        public int Id { get { return _Id; } set { _Id = value; } }

        public string Description { get { return _Descripcion; } set { _Descripcion = value; } }

        public int WeekHours { get { return _WeekHours; } set { _WeekHours = value; } }

        public int TotalHours { get { return _TotalHours;} set { _TotalHours = value; } }

        public int IdPlan { get { return _IdPlan.Id; } set { _IdPlan.Id = value; } }

        public Curriculum Curriculum { get { return _IdPlan; } set { _IdPlan = value; } }
        #endregion

        #region constructors

        public Subject(string name, int weekHours)

        {
            _Descripcion = name;
            _WeekHours = weekHours;
        }

        public Subject(int id, string description, Curriculum curriculum, int weekHours, int totalHours)
        {
            _Id = id;
            _Descripcion = description ?? throw new ArgumentNullException(nameof(description));
            _IdPlan = curriculum ?? throw new ArgumentNullException(nameof(curriculum));
            _WeekHours = weekHours;
            _TotalHours = totalHours;
        }

        public Subject(string description, Curriculum curriculum, int weekHours, int totalHours)
        {

            _Descripcion = description ?? throw new ArgumentNullException(nameof(description));
            _IdPlan = curriculum ?? throw new ArgumentNullException(nameof(curriculum));
            _WeekHours = weekHours;
            _TotalHours = totalHours;
        }
        #endregion
    }
}

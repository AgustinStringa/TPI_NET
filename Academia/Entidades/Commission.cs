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
        //private int _Year;
        private Curriculum _Curriculum;
        private int _IdCurriculum;
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
        //public int Year
        //{
        //    get { return _Year; }
        //    set { _Year = value; }
        //}
        public Curriculum Curriculum
        {
            get { return _Curriculum; }
            set { _Curriculum = value; }
        }
        public int IdCurriculum
        {
            get { return _IdCurriculum; }
            set { _IdCurriculum = value; }
        }
        #endregion

        #region constructors
        //public Commission(string description, int year)
        //{
        //    _Description = description;
        //    _Year = year;
        //}

        //public Commission(string description, int year, int id)
        //{
        //    _Id = id;
        //    _Description = description;
        //    _Year = year;
        //}

        // constructor provided by user
        public Commission(string description,  int curriculum)
        {
            _Description = description;
            _IdCurriculum = curriculum;
        }

        //constructor provided by database
        public Commission(string description, Curriculum curriculum, int id)
        {
            _Curriculum = curriculum;
            _Description = description;
            _Id = id;
        }
        #endregion
    }
}

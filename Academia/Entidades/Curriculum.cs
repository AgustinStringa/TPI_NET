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
        private int _Year;
        private string _Resolution;
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



        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        public string Resolution
        {
            get { return _Resolution; }
            set { _Resolution = value; }
        }


        #endregion

        #region constructors
        public Curriculum(int id, string description, Area area, int year, string resolution)
        {
            _Id = id;
            _Description = description ?? throw new ArgumentNullException(nameof(description));
            _Area = area ?? throw new ArgumentNullException(nameof(area));
            _Year = year;
            _Resolution = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        public Curriculum( string description, int area, int year, string resolution)
        {
            _Description = description ?? throw new ArgumentNullException(nameof(description));
            _Year = year;
            _Resolution = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        #endregion




    }
}

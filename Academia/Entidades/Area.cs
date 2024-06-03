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
        //constructor used with values provided by user

        public Area(string description) {
            _Description = description;
		}

        //constructor used with values provided by database
        public Area(string description, int id)
        {
            _Description = description;
            _IdArea = id;
        }
        #endregion

        public IEnumerable<Curriculum> GetCurriculums() {
            List<Curriculum> items = new List<Curriculum>();
            
            switch (Description)
            {
                case "Sistemas":
                    
                    //items.Add(new Curriculum("isi23", this));
                    //items.Add(new Curriculum("isi08", this));
                    //items.Add(new Curriculum("isi95", this));

                    
                    break;
                case "Quimica":
                    
                    //items.Add(new Curriculum("IQ22", this));
                  
                    
                    break;
                default:
                    
                    //items.Add(new Curriculum("isi23", this));
                    //items.Add(new Curriculum("isi08", this));
                    //items.Add(new Curriculum("isi95", this));
                    break;
            }

            //query to DB and return Curriculms with this area

            return items;
            
        } 
    }
}

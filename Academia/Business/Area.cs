using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Business
{
    public class Area
    {
        public void Create(Entities.Area newArea)
        {
            //validations and call to Data Layout
        }
        public void FindOne(int id) { }
        public IEnumerable<Entities.Area> FindAll()
        {
            return new List<Entities.Area>();
        }
        public void Update() { }
        public void Delete(int id) { }
    }
}

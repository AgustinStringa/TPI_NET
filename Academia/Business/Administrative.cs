using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Business
{
    public class Administrative
    {
        public async static Task<Entities.Administrative> Create(Entities.Administrative newAdministrative)

        {
            //validations and call to Data Layout
            var administrativeExists = await Data.Area.FindOne(newAdministrative.Id);
            if (administrativeExists != null)
            {
                throw new Exception("Este administrativo ya existe.");
            }
            var administrativo = await Data.Administrative.Create(newAdministrative);
            return administrativo;
        }

        public async static Task<Entities.Administrative> FindOne(int id)
        {
            var administrative = await Data.Administrative.FindOne(id);
            return administrative;
        }


    }
}

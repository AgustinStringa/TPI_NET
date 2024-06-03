using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Business
{
    public class Area
    {
        public async static Task<Entities.Area> Create(Entities.Area newArea)

        {
            //validations and call to Data Layout
            var areaExists = await Data.Area.FindOne(newArea.Description);
            if (areaExists!= null) {
                throw new Exception("Esta especialidad ya existe.");
            }
            var area = await Data.Area.Create(newArea);
            return area;
        }
        public async static Task<Entities.Area> FindOne(int id) {
            var area = await Data.Area.FindOne(id);
            return area;
        }
        public async static Task<List<Entities.Area>> FindAll()
        {
            var areas = await Data.Area.FindAll();
            return areas;
        }
        public async static Task<Entities.Area> Update(Entities.Area updatedArea) {
            await Data.Area.Update(updatedArea);
            return await Data.Area.FindOne(Int32.Parse(updatedArea.IdArea.ToString()));
        }
        public static async Task<Entities.Area> Delete(int id) {
            var deletedArea = await Data.Area.FindOne(id);
            await Data.Area.Delete(id);
            return deletedArea; 
        }
    }
}

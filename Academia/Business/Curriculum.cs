using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Curriculum
    {
        public static async Task<Entities.Curriculum> Create(Entities.Curriculum newCurr)
        {
            //validations and cALL data layout
            try
            {
                return await Data.Curriculum.Create(newCurr);

            }
            catch (Exception ex)
            {

                throw ex;
                return null;
            }

        }

        public async static Task<List<Entities.Curriculum>> FindAll() {
            var curriculums = await Data.Curriculum.FindAll();
            return curriculums;
        }

        public async static Task<Entities.Curriculum> Update(Entities.Curriculum updatedCurr) {

            if (await Data.Curriculum.Update(updatedCurr) == 1) {
                return updatedCurr;
            } else
            {
                return null;
            }

        }


        public async static Task<Entities.Curriculum> Delete(int id) {
            var deletedCurriculum = await Data.Curriculum.FindOne(id);
            await Data.Curriculum.Delete(id);
            return deletedCurriculum;
        }

        public static async Task<Entities.Curriculum> FindOne(int id)
        {
            return await Data.Curriculum.FindOne(id);
        }
    }
}

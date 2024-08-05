using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;


namespace Business
{
    public class Subject
    {
        public static async Task<Entities.Subject> Create(Entities.Subject newSubject)
        {
            //validations and cALL data layout
            try
            {
                return await Data.Subject.Create(newSubject);

            }
            catch (Exception ex)
            {

                throw ex;
                return null;
            }

        }

        public async static Task<List<Entities.Subject>> FindAll()
        {
            var subjects = await Data.Subject.FindAll();
            return subjects;
        }

        public async static Task<Entities.Subject> Update(Entities.Subject updatedSubject)
        {

            if (await Data.Subject.Update(updatedSubject) == 1)
            {
                return updatedSubject;
            }
            else
            {
                return null;
            }

        }


        public async static Task<Entities.Subject> Delete(int id)
        {
            var deletedSubject = await Data.Subject.FindOne(id);
            await Data.Subject.Delete(id);
            return deletedSubject;
        }

        public static async Task<Entities.Subject> FindOne(int id)
        {
            return await Data.Subject.FindOne(id);
        }
    }
}

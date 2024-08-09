using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Business
{
    public class Commission
    {
        public async static Task<Entities.Commission> Create(Entities.Commission newCommission)
        {
            var commission = await Data.Commission.Create(newCommission);
            return commission;
        }

        public async static Task<Entities.Commission> FindOne(int id)
        {
            var commission = await Data.Commission.FindOne(id);
            return commission;
        }

        public async static Task<List<Entities.Commission>> FindAll()
        {
            var commissions = await Data.Commission.FindAll();
            return commissions;
        }

        public async static Task<Entities.Commission> Update(Entities.Commission updatedCommission)
        {
            await Data.Commission.Update(updatedCommission);
            return await Data.Commission.FindOne(Int32.Parse(updatedCommission.IdCommission.ToString()));
        }

        public async static Task<Entities.Commission> Delete(int id)
        {
            var deletedCommission = await Data.Commission.FindOne(id);
            await Data.Commission.Delete(id);
            return deletedCommission;
        }
    }
}

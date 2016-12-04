using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;
using Martijn.HouseInsight.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace Martijn.HouseInsight.EntityFramework.Stores
{
    public class RetailStore : EntityFrameworkStoreBase, IRetailStore
    {
        public RetailStore(HouseInsightContext context) : base(context) { }

        public async Task AddAsync(Retail retail)
        {
            Context.Retails.Add(retail);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Retail>> GetAllAsync()
        {
            return await Context.Retails.ToListAsync();
        }

        public async Task<Retail> GetByIdAsync(int id)
        {
            return await Context.Retails.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Retail retail)
        {
            var entry = Context.Retails.Attach(retail);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Retail retail)
        {
            Context.Retails.Remove(retail);
            await Context.SaveChangesAsync();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;
using Martijn.HouseInsight.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace Martijn.HouseInsight.EntityFramework.Stores
{
    public class ItemGroupStore : EntityFrameworkStoreBase, IItemGroupStore
    {
        public ItemGroupStore(HouseInsightContext context) : base(context) { }

        public async Task AddAsync(ItemGroup itemGroup)
        {
            Context.ItemGroups.Add(itemGroup);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemGroup>> GetAllAsync()
        {
            return await Context.ItemGroups.ToListAsync();
        }

        public async Task<ItemGroup> GetByIdAsync(int id)
        {
            return await Context.ItemGroups.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ItemGroup> GetByIdWithItemTypesAsync(int id)
        {
            return await Context.ItemGroups.Include(x => x.ItemTypes).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(ItemGroup itemGroup)
        {
            var entry = Context.ItemGroups.Attach(itemGroup);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(ItemGroup itemGroup)
        {
            Context.ItemGroups.Remove(itemGroup);
            await Context.SaveChangesAsync();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;
using Martijn.HouseInsight.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace Martijn.HouseInsight.EntityFramework.Stores
{
    public class ItemPriorityStore : EntityFrameworkStoreBase, IItemPriorityStore
    {
        public ItemPriorityStore(HouseInsightContext context) : base(context) { }

        public async Task AddAsync(ItemPriority itemPriority)
        {
            Context.ItemPriorities.Add(itemPriority);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemPriority>> GetAllAsync()
        {
            return await Context.ItemPriorities.ToListAsync();
        }

        public async Task<ItemPriority> GetByIdAsync(int id)
        {
            return await Context.ItemPriorities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ItemPriority> GetByIdWithItemTypesAsync(int id)
        {
            return await Context.ItemPriorities.Include(x => x.ItemTypes).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(ItemPriority itemPriority)
        {
            var entry = Context.ItemPriorities.Attach(itemPriority);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(ItemPriority itemPriority)
        {
            Context.ItemPriorities.Remove(itemPriority);
            await Context.SaveChangesAsync();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;
using Martijn.HouseInsight.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace Martijn.HouseInsight.EntityFramework.Stores
{
    public class ItemTypeStore : EntityFrameworkStoreBase, IItemTypeStore
    {
        public ItemTypeStore(HouseInsightContext context, IItemGroupStore itemGroupStore,
            IItemPriorityStore itemPriorityStore, IRoomStore roomStore) : base(context)
        {
            ItemGroupStore = itemGroupStore;
            ItemPriorityStore = itemPriorityStore;
            RoomStore = roomStore;
        }

        protected IItemGroupStore ItemGroupStore { get; set; }

        protected IItemPriorityStore ItemPriorityStore { get; set; }

        protected IRoomStore RoomStore { get; set; }

        public async Task AddAsync(ItemType itemType)
        {
            Context.ItemTypes.Add(itemType);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemType>> GetAllByGroupIdAsync(int groupId)
        {
            var group = await ItemGroupStore.GetByIdWithItemTypesAsync(groupId);
            return group.ItemTypes;
        }

        public async Task<IEnumerable<ItemType>> GetAllByPriorityIdAsync(int priorityId)
        {
            var priority = await ItemPriorityStore.GetByIdWithItemTypesAsync(priorityId);
            return priority.ItemTypes;
        }

        public async Task<IEnumerable<ItemType>> GetAllByRoomIdAsync(int roomId)
        {
            var room = await RoomStore.GetByIdWithItemTypesAsync(roomId);
            return room.ItemTypes.Select(x => x.ItemType);
        }

        public async Task<IEnumerable<ItemType>> GetAllAsync()
        {
            return await Context.ItemTypes.ToListAsync();
        }

        public async Task<ItemType> GetByIdAsync(int id)
        {
            return await Context.ItemTypes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ItemType> GetByIdWithProductsAsync(int id)
        {
            return await Context.ItemTypes.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(ItemType itemType)
        {
            var entry = Context.ItemTypes.Attach(itemType);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(ItemType itemType)
        {
            Context.ItemTypes.Remove(itemType);
            await Context.SaveChangesAsync();
        }
    }
}

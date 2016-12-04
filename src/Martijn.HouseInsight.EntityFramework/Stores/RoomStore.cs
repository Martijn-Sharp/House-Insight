using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;
using Martijn.HouseInsight.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace Martijn.HouseInsight.EntityFramework.Stores
{
    public class RoomStore : EntityFrameworkStoreBase, IRoomStore
    {
        public RoomStore(HouseInsightContext context) : base(context) { }

        public async Task AddAsync(Room room)
        {
            Context.Rooms.Add(room);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await Context.Rooms.ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await Context.Rooms.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Room> GetByIdWithItemTypesAsync(int id)
        {
            return await Context.Rooms.Include(x => x.ItemTypes).ThenInclude(x => x.ItemType).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Room room)
        {
            var entry = Context.Rooms.Attach(room);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Room room)
        {
            Context.Rooms.Remove(room);
            await Context.SaveChangesAsync();
        }
    }
}

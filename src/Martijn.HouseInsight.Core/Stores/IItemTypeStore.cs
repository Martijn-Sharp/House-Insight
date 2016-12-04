using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;

namespace Martijn.HouseInsight.Core.Stores
{
    public interface IItemTypeStore
    {
        Task AddAsync(ItemType itemType);

        Task<IEnumerable<ItemType>> GetAllByGroupIdAsync(int groupId);

        Task<IEnumerable<ItemType>> GetAllByPriorityIdAsync(int priorityId);

        Task<IEnumerable<ItemType>> GetAllByRoomIdAsync(int roomId);

        Task<IEnumerable<ItemType>> GetAllAsync();

        Task<ItemType> GetByIdAsync(int id);

        Task<ItemType> GetByIdWithProductsAsync(int id);

        Task UpdateAsync(ItemType itemType);

        Task RemoveAsync(ItemType itemType);
    }
}
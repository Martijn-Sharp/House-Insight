using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;

namespace Martijn.HouseInsight.Core.Stores
{
    public interface IItemPriorityStore
    {
        Task AddAsync(ItemPriority itemPriority);

        Task<IEnumerable<ItemPriority>> GetAllAsync();

        Task<ItemPriority> GetByIdAsync(int id);

        Task UpdateAsync(ItemPriority itemPriority);

        Task RemoveAsync(ItemPriority itemPriority);
    }
}

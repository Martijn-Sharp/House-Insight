using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;

namespace Martijn.HouseInsight.Core.Stores
{
    public interface IItemGroupStore
    {
        Task AddAsync(ItemGroup itemGroup);

        Task<IEnumerable<ItemGroup>> GetAllAsync();

        Task<ItemGroup> GetByIdAsync(int id);

        Task UpdateAsync(ItemGroup itemGroup);

        Task RemoveAsync(ItemGroup itemGroup);
    }
}

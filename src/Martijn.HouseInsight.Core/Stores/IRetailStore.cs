using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;

namespace Martijn.HouseInsight.Core.Stores
{
    public interface IRetailStore
    {
        Task AddAsync(Retail retail);

        Task<IEnumerable<Retail>> GetAllAsync();

        Task<Retail> GetByIdAsync(int id);

        Task UpdateAsync(Retail retail);

        Task RemoveAsync(Retail retail);
    }
}

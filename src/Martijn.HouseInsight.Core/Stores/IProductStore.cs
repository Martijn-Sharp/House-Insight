using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;

namespace Martijn.HouseInsight.Core.Stores
{
    public interface IProductStore
    {
        Task AddAsync(int itemTypeId, Product product);

        Task<IEnumerable<Product>> GetAllByItemTypeIdAsync(int itemTypeId);

        Task<Product> GetByIdAsync(int id);

        Task UpdateAsync(Product product);

        Task RemoveAsync(Product product);
    }
}

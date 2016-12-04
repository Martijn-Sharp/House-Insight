using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;

namespace Martijn.HouseInsight.Core.Stores
{
    public interface IRetailProductStore
    {
        Task AddAsync(int retailId, int productId, RetailProduct retailProduct);

        Task<IEnumerable<RetailProduct>> GetAllByProductIdAsync(int productId);

        Task<IEnumerable<RetailProduct>> GetAllByRetailIdAsync(int retailId);

        Task<RetailProduct> GetByIdAsync(int retailId, int productId);

        Task UpdateAsync(RetailProduct retailProduct);

        Task RemoveAsync(RetailProduct retailProduct);
    }
}

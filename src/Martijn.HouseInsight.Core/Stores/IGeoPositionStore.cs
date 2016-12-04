using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;

namespace Martijn.HouseInsight.Core.Stores
{
    public interface IGeoPositionStore
    {
        Task AddAsync(int retailId, GeoPosition geoPosition);

        Task<IEnumerable<GeoPosition>> GetAllByRetailIdAsync(int retailId);

        Task<GeoPosition> GetByIdAsync(int id);

        Task UpdateAsync(GeoPosition geoPosition);

        Task RemoveAsync(GeoPosition geoPosition);
    }
}

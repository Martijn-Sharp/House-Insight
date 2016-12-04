using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;

namespace Martijn.HouseInsight.Core.Stores
{
    public interface IRoomStore
    {
        Task AddAsync(Room room);

        Task<IEnumerable<Room>> GetAllAsync();

        Task<Room> GetByIdAsync(int id);

        Task<Room> GetByIdWithItemTypesAsync(int id);

        Task UpdateAsync(Room room);

        Task RemoveAsync(Room room);
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;
using Martijn.HouseInsight.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace Martijn.HouseInsight.EntityFramework.Stores
{
    public class GeoPositionStore : EntityFrameworkStoreBase, IGeoPositionStore
    {
        public GeoPositionStore(HouseInsightContext context, IRetailStore retailStore) : base(context)
        {
            RetailStore = retailStore;
        }

        protected IRetailStore RetailStore { get; set; }

        public async Task AddAsync(int retailId, GeoPosition geoPosition)
        {
            var retail = await RetailStore.GetByIdWithLocationsAsync(retailId);
            retail.Locations.Add(geoPosition);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GeoPosition>> GetAllByRetailIdAsync(int retailId)
        {
            var retail = await RetailStore.GetByIdWithLocationsAsync(retailId);
            return retail?.Locations;
        }

        public async Task<GeoPosition> GetByIdAsync(int id)
        {
            return await Context.GeoPositions.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(GeoPosition geoPosition)
        {
            var entry = Context.GeoPositions.Attach(geoPosition);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(GeoPosition geoPosition)
        {
            Context.GeoPositions.Remove(geoPosition);
            await Context.SaveChangesAsync();
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Martijn.HouseInsight.EntityFramework.Stores;
using Xunit;

namespace Martijn.HouseInsight.EntityFramework.Tests.Stores
{
    public class GeoPositionStoreTests : StoreTestsBase
    {
        [Fact]
        public async Task Basic_AddAsync_Test()
        {
            // Create entities
            var retail = DefaultModelInstances.CreateRetail();
            var geoPosition = DefaultModelInstances.CreateGeoPosition();

            // Create a context to save the entities with
            using (var context = CreateContext())
            {
                var retailStore = new RetailStore(context);
                await retailStore.AddAsync(retail);
                
                var geoPositionStore = new GeoPositionStore(context, retailStore);
                await geoPositionStore.AddAsync(retail.Id, geoPosition);
            }

            // Create a context to assert if objects have been added correctly
            using (var context = CreateContext())
            {
                var retailStore = new RetailStore(context);
                var geoPositionStore = new GeoPositionStore(context, retailStore);
                var dbGeoPosition = await geoPositionStore.GetByIdAsync(geoPosition.Id);
                Assert.NotNull(geoPosition);
                Assert.Equal(geoPosition.Longitude, dbGeoPosition.Longitude);
                Assert.Equal(geoPosition.Latitude, dbGeoPosition.Latitude);

                var geoPositions = await geoPositionStore.GetAllByRetailIdAsync(retail.Id);
                Assert.True(geoPositions.Any(x => x.Id == geoPosition.Id));
            }
        }
    }
}

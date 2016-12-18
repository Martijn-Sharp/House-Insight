using System.Threading.Tasks;
using Martijn.HouseInsight.EntityFramework.Stores;
using Xunit;

namespace Martijn.HouseInsight.EntityFramework.Tests.Stores
{
    public class ItemGroupStoreTests : StoreTestsBase
    {
        [Fact]
        public async Task Basic_AddAsync_Test()
        {
            // Create entity
            var itemGroup = DefaultModelInstances.CreateItemGroup();

            // Create a context to save the entity with
            using (var context = CreateContext())
            {
                var itemGroupStore = new ItemGroupStore(context);
                await itemGroupStore.AddAsync(itemGroup);
            }

            // Create a context to assert if object has been added correctly
            using (var context = CreateContext())
            {
                var itemGroupStore = new ItemGroupStore(context);
                var dbItemGroup = await itemGroupStore.GetByIdAsync(itemGroup.Id);
                Assert.NotNull(dbItemGroup);
                Assert.Equal(itemGroup.Name, dbItemGroup.Name);
            }
        }

        [Fact]
        public async Task Basic_RemoveAsync_Test()
        {
            // Create entity
            var itemGroup = DefaultModelInstances.CreateItemGroup();

            // Create a context to save the entity with
            using (var context = CreateContext())
            {
                var itemGroupStore = new ItemGroupStore(context);
                await itemGroupStore.AddAsync(itemGroup);
            }

            // Create a context to assert if objects have been removed correctly
            using (var context = CreateContext())
            {
                var itemGroupStore = new ItemGroupStore(context);
                await itemGroupStore.RemoveAsync(itemGroup);

                var result = await itemGroupStore.GetByIdAsync(itemGroup.Id);
                Assert.Null(result);
            }
        }
    }
}

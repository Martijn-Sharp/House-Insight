using Microsoft.EntityFrameworkCore;

namespace Martijn.HouseInsight.EntityFramework.Tests.Stores
{
    public abstract class StoreTestsBase
    {
        protected StoreTestsBase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HouseInsightContext>();
            optionsBuilder.UseInMemoryDatabase();
            ContextOptions = optionsBuilder.Options;
        }

        protected DbContextOptions<HouseInsightContext> ContextOptions { get; }

        protected HouseInsightContext CreateContext()
        {
            return new HouseInsightContext(ContextOptions);
        }
    }
}

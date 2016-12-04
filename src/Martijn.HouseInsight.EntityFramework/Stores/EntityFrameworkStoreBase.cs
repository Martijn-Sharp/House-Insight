namespace Martijn.HouseInsight.EntityFramework.Stores
{
    public abstract class EntityFrameworkStoreBase
    {
        protected EntityFrameworkStoreBase(HouseInsightContext context)
        {
            Context = context;
        }

        protected HouseInsightContext Context { get; set; }
    }
}

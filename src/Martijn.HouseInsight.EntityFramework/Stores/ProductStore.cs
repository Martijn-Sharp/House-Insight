using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;
using Martijn.HouseInsight.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace Martijn.HouseInsight.EntityFramework.Stores
{
    public class ProductStore : EntityFrameworkStoreBase, IProductStore
    {
        public ProductStore(HouseInsightContext context, IItemTypeStore itemTypeStore) : base(context)
        {
            ItemTypeStore = itemTypeStore;
        }

        protected IItemTypeStore ItemTypeStore { get; set; }

        public async Task AddAsync(int itemTypeId, Product product)
        {
            var itemType = await ItemTypeStore.GetByIdWithProductsAsync(itemTypeId);
            itemType.Products.Add(product);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByItemTypeIdAsync(int itemTypeId)
        {
            var itemType = await ItemTypeStore.GetByIdWithProductsAsync(itemTypeId);
            return itemType.Products;
        }
        
        public async Task<Product> GetByIdAsync(int id)
        {
            return await Context.Products.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetByIdWithRetailsAsync(int id)
        {
            return await Context.Products.Include(x => x.RetailProducts).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            var entry = Context.Products.Attach(product);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Product product)
        {
            Context.Products.Remove(product);
            await Context.SaveChangesAsync();
        }
    }
}

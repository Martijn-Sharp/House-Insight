using System.Collections.Generic;
using System.Threading.Tasks;
using Martijn.HouseInsight.Core.Models;
using Martijn.HouseInsight.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace Martijn.HouseInsight.EntityFramework.Stores
{
    public class RetailProductStore : EntityFrameworkStoreBase, IRetailProductStore
    {
        public RetailProductStore(HouseInsightContext context, IRetailStore retailStore, IProductStore productStore) : base(context)
        {
            RetailStore = retailStore;
            ProductStore = productStore;
        }

        protected IRetailStore RetailStore { get; set; }

        protected IProductStore ProductStore { get; set; }

        public async Task AddAsync(int retailId, int productId, RetailProduct retailProduct)
        {
            var retail = await RetailStore.GetByIdWithProductsAsync(retailId);
            var product = await ProductStore.GetByIdWithRetailsAsync(productId);
            retail.RetailProducts.Add(retailProduct);
            product.RetailProducts.Add(retailProduct);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RetailProduct>> GetAllByProductIdAsync(int productId)
        {
            var product = await ProductStore.GetByIdWithRetailsAsync(productId);
            return product.RetailProducts;
        }

        public async Task<IEnumerable<RetailProduct>> GetAllByRetailIdAsync(int retailId)
        {
            var retail = await RetailStore.GetByIdWithProductsAsync(retailId);
            return retail.RetailProducts;
        }

        public async Task<RetailProduct> GetByIdAsync(int retailId, int productId)
        {
            return await Context.RetailProducts.SingleOrDefaultAsync(x => x.ProductId == productId && x.RetailId == retailId);
        }

        public async Task UpdateAsync(RetailProduct retailProduct)
        {
            var entry = Context.RetailProducts.Attach(retailProduct);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(RetailProduct retailProduct)
        {
            Context.RetailProducts.Remove(retailProduct);
            await Context.SaveChangesAsync();
        }
    }
}

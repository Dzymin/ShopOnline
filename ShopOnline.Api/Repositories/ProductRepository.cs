using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _dbcontext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext) 
        {
               _dbcontext = shopOnlineDbContext;
        }
        
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await _dbcontext.ProductCategories.ToListAsync();

            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            ProductCategory category = await _dbcontext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            Product product = await _dbcontext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await _dbcontext.Products.ToListAsync();

            return products;
        }
    }
}

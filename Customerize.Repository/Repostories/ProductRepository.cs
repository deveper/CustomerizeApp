using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Customerize.Repository.Repostories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepositroy
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetFullProduct()
        {
            var fullProduct = await _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductType)
                .ToListAsync();
            return fullProduct;
        }
    }
}

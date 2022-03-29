using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Repository.Repostories
{
    public class ProductTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<ProductType>> GetAllProductType()
        {
            var productType = await _context.ProductTypes
                .Include(x => x.Products)
                .ToListAsync();
            return productType;
        }
    }
}

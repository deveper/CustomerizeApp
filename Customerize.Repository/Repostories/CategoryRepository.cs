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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetCategoryWithProduct()
        {
            var categoryWithProduct = await _context.Categories
                .Include(x => x.Products)
                .ToListAsync();
            return categoryWithProduct;
        }

        public async Task<Category> GetCategoryWithProduct(int id)
        {
            var categoryWithProduct = _context.Categories.Where(x => x.Id == id)
                         .Include(x => x.Products).FirstOrDefault();
            return categoryWithProduct;
        }
    }
}

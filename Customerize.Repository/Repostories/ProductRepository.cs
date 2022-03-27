using Customerize.Core.Entities;
using Customerize.Core.Repositories;

namespace Customerize.Repository.Repostories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepositroy
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}

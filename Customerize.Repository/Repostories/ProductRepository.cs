using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Repository.Repostories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepositroy
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}

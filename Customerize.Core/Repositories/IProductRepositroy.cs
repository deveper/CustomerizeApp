﻿using Customerize.Core.Entities;

namespace Customerize.Core.Repositories
{
    public interface IProductRepositroy : IGenericRepository<Product>
    {
        Task<List<Product>> GetFullProduct();
    }
}

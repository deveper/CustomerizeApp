﻿using Customerize.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Repositories
{
    public interface IProductTypeRepository:IGenericRepository<ProductType>
    {
        Task<List<ProductType>> GetAllProductType();

    }
}

using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<List<CategoryDtoWithProductList>> GetCategoryWithProduct();
        Task<Category> GetCategoryWithProduct(int id);

    }
}

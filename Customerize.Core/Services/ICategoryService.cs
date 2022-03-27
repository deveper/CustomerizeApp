using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;

namespace Customerize.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<List<CategoryDtoWithProductList>> GetCategoryWithProduct();
        Task<Category> GetCategoryWithProduct(int id);

    }
}

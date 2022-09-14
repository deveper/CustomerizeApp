using Common.Dtos;
using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;
namespace Customerize.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<List<CategoryDtoWithProductList>> GetCategoryWithProduct();
        Task<CategoryDtoWithProductList> GetCategoryWithProductId(int id);
        Task<ResultDto<Category>> GetCategoryById(int Id);
        Task<ResultDto> UpdateCategory(CategoryDtoUpdate input);
    }
}

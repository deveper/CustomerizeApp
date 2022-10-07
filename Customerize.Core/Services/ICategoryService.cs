using Common.Dtos;
using Customerize.Common.Dtos;
using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;
namespace Customerize.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<IEnumerable<CategoryDtoWithProductList>> GetCategoryWithProduct();
        Task<CategoryDtoWithProductList> GetCategoryWithProductId(int id);
        Task<ResultDto<CategoryDtoUpdate>> GetCategoryById(int Id);
        Task<ResultDto> UpdateCategory(CategoryDtoUpdate input);

        ResultDto<List<CategoryDtoList>> GetAllCategoryForDataTable(DataTableModel input);
    }
}

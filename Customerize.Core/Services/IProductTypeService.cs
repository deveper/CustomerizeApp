using Customerize.Core.DTOs.ProductType;
using Customerize.Core.Entities;

namespace Customerize.Core.Services
{
    public interface IProductTypeService : IService<ProductType>
    {
        Task<List<ProductTypeDtoList>> GetAllProductType();
    }
}

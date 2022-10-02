using Common.Dtos;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;

namespace Customerize.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<ResultDto<IEnumerable<ProductDtoList>>> GetProductAllDetail();
        Task<ResultDto<IList<ProductDtoRemoveRange>>> RemoveRangeProduct(IList<ProductDtoRemoveRange> input);
        Task<ResultDto> Create(ProductDtoInsert input);
    }
}

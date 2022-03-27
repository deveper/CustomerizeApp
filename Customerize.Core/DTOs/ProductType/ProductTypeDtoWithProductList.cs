using Customerize.Core.DTOs.Product;

namespace Customerize.Core.DTOs.ProductType
{
    public class ProductTypeDtoWithProductList : BaseDto
    {
        public string Name { get; set; }
        public ICollection<ProductDto> ProductDtos { get; set; }
    }
}

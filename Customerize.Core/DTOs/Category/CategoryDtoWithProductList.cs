using Customerize.Core.DTOs.Product;

namespace Customerize.Core.DTOs.Category
{
    public class CategoryDtoWithProductList : BaseDto
    {
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; }

    }
}

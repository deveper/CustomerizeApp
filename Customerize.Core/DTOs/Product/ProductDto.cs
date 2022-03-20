using Customerize.Core.DTOs.Category;

namespace Customerize.Core.DTOs.Product
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public CategoryDtoWithProductList Category { get; set; }
        public int CategoryId { get; set; }

    }
}

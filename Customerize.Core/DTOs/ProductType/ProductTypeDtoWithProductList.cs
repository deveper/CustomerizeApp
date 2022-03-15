using Customerize.Core.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.DTOs.ProductType
{
    public class ProductTypeDtoWithProductList : BaseDto
    {
        public string Name { get; set; }
        public ICollection<ProductDto> ProductDtos { get; set; }
    }
}

using Microsoft.AspNetCore.Http;

namespace Customerize.Core.DTOs.Product
{
    public class ProductDtoInsert
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductTypeId { get; set; }
        public IEnumerable<IFormFile>? formFiles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Customerize.Core.DTOs.Product
{
    public class ProductDtoRemoveRange: BaseDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ProductTypeId { get; set; }
        public string CategoryName { get; set; }
        public string ProductTypeName { get; set; }
        public SelectListItem DeleteProducts { get; set; }
    }
}

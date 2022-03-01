using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        //navigation property
        public int ProductTypeId { get; set; }
        public ProductType productType { get; set; }

        //navigation property
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

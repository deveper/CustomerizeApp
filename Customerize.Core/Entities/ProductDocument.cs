using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Entities
{
    public class ProductDocument : BaseEntity
    {
        public string Title { get; set; }
        public string Path { get; set; }
        //navigation property
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        //navigation property
        public ICollection<Product> Products { get; set; }
    }
}

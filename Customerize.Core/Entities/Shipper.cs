using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Entities
{
    public class Shipper : BaseEntity
    {
        public string Name { get; set; }
        public string WorkRegion { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

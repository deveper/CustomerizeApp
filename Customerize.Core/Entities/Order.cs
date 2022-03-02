using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Entities
{
    public class Order : BaseEntity
    {
        public string OrderCode { get; set; }

        //navigation property
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }

        //navigation property
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        //navigation property
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}

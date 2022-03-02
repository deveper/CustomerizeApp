using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string TaxNumber { get; set; }
        public string WorkArea { get; set; }


        //navigation property
        public IQueryable<Order> Orders { get; set; }
    }
}

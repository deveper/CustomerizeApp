using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Entities
{
    public class AppUser : BaseEntity
    {
        //navigation property
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        //navigation property
        public IQueryable<Order> Orders { get; set; }
    }
}

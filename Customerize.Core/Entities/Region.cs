using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Entities
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }

        //navigation property
        public ICollection<RegionShipper> RegionShippers { get; set; }
    }
}

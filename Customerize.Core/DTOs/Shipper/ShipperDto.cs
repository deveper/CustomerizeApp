using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.DTOs.Shipper
{
    public class ShipperDto : BaseDto
    {
        public string Name { get; set; }
        public string WorkRegion { get; set; }
    }
}

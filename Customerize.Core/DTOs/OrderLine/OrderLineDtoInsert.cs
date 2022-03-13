using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.DTOs.OrderLine
{
    public class OrderLineDtoInsert : BaseDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
    }
}

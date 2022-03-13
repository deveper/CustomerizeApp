using Customerize.Core.DTOs.OrderLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.DTOs.Order
{
    public class OrderDtoWithOrderLineList : BaseDto
    {
        public int OrderId { get; set; }
        public ICollection<OrderLineDto> OrderLineDtos { get; set; }
    }
}

using Customerize.Core.DTOs.OrderLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.DTOs
{
    public class OrderDto : BaseDto
    {
        public string OrderCode { get; set; }
        public ICollection<OrderLineDto> OrderLineDtos { get; set; }
        public int ShipperId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

    }
}

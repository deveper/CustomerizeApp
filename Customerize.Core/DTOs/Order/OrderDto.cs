﻿using Customerize.Core.DTOs.OrderLine;

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

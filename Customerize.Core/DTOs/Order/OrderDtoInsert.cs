﻿using Customerize.Core.DTOs.OrderLine;
using Customerize.Core.DTOs.Product;

namespace Customerize.Core.DTOs.Order
{

    public class OrderDtoInsert : BaseDto
    {
        public OrderDtoInsert()
        {
            Products = new List<ProductDtoList>();
        }
        public int UserId { get; set; } = 1;
        public int CompanyId { get; set; } = 3;
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public string? Description { get; set; }
        

        public List<OrderLineDtoInsert> OrderLines { get; set; }
        public List<ProductDtoList> Products { get; set; }
    }
}

﻿namespace Customerize.Core.DTOs.Shipper
{
    public class ShipperDtoWithOrder : BaseDto
    {
        public string Name { get; set; }
        public string WorkRegion { get; set; }
        public ICollection<OrderDto> OrderDtos { get; set; }
    }
}

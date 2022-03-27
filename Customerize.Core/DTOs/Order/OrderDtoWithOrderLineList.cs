using Customerize.Core.DTOs.OrderLine;

namespace Customerize.Core.DTOs.Order
{
    public class OrderDtoWithOrderLineList : BaseDto
    {
        public int OrderId { get; set; }
        public ICollection<OrderLineDto> OrderLineDtos { get; set; }
    }
}

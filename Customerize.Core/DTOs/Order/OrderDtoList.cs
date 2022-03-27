using Customerize.Core.DTOs.OrderLine;

namespace Customerize.Core.DTOs.Order
{
    public class OrderDtoList : BaseDto
    {
        public string OrderCode { get; set; }
        public int ShipperId { get; set; }
        public int CompanyId { get; set; }
        public ICollection<OrderLineDto> OrderLineDtos { get; set; }
    }
}

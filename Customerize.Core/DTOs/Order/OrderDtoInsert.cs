using Customerize.Core.DTOs.OrderLine;

namespace Customerize.Core.DTOs.Order
{
    public class OrderDtoInsert : BaseDto
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public ICollection<OrderLineDto> OrderLineDtos { get; set; }
    }
}

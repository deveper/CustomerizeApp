namespace Customerize.Core.DTOs.OrderLine
{
    public class OrderLineDto : BaseDto
    {

        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}

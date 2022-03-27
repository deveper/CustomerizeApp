namespace Customerize.Core.DTOs.OrderLine
{
    public class OrderLineDtoInsert : BaseDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
    }
}

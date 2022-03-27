namespace Customerize.Core.DTOs.OrderLine
{
    public class OrderLineDtoUpdate : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}

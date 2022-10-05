namespace Customerize.Core.DTOs.OrderLine
{
    public class OrderLineDtoList : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPiece { get; set; }
        public decimal? LineAmount { get; set; }

    }
}

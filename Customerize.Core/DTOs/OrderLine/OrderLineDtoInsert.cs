namespace Customerize.Core.DTOs.OrderLine
{
    public class OrderLineDtoInsert : BaseDto
    {
        public string Name { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductTypeId { get; set; }
        public int ProductPiece { get; set; }
        public int LastStock { get; set; }
        public string Price { get; set; }
    }
}

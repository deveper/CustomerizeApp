namespace Customerize.Core.DTOs.OrderLine
{
    public class OrderLineDto : BaseDto
    {

        public int OrderId { get; set; }
        public List<int> PorductId { get; set; }//birden fazla ürün olacak
    }
}

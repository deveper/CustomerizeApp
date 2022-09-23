namespace Customerize.Core.DTOs.OrderLine
{
    public class OrderLineDto : BaseDto
    {

        public List<int> PorductId { get; set; }//birden fazla ürün olacak
    }
}

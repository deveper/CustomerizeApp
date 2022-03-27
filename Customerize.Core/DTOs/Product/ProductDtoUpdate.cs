namespace Customerize.Core.DTOs.Product
{
    public class ProductDtoUpdate : BaseDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ProcductTypeId { get; set; }
    }
}

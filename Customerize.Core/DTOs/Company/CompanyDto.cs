namespace Customerize.Core.DTOs.Company
{
    public class CompanyDto : BaseDto
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string TaxNumber { get; set; }
        public string WorkArea { get; set; }
        public ICollection<OrderDto> OrderDtos { get; set; }
    }
}

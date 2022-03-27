namespace Customerize.Core.DTOs.Company
{
    public class CompanyDtoWithOrderList
    {
        public ICollection<OrderDto> OrderDtos { get; set; }
    }
}

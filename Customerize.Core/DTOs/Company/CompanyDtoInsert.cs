namespace Customerize.Core.DTOs.Company
{
    public class CompanyDtoInsert : BaseDto
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string TaxNumber { get; set; }
        public string WorkArea { get; set; }

        public string? CompanyPhoneNumber { get; set; }
    }
}

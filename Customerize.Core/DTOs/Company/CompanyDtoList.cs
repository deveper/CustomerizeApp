
using Common.Dtos;
using Customerize.Core.DTOs.WorkArea;
using Customerize.Core.Entities;
namespace Customerize.Core.DTOs.Company
{
    public class CompanyDtoList : BaseDto
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string TaxNumber { get; set; }
        public int WorkArea { get; set; }

        public WorkAreaDtoList WorkAreaDetail { get; set; }

        public string WorkAreaName { get; set; }

        public string WorkAreaIsInternal { get; set; }
    }
}

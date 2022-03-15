using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.DTOs.Company
{
    public class CompanyDtoWithOrderList
    {
        public ICollection<OrderDto> OrderDtos { get; set; }
    }
}

using Customerize.Core.DTOs.OrderLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.DTOs.Order
{
    public class OrderDtoDetails
    {
        public string CompanyName { get; set; }
        public IList<OrderLineDtoList> OrderLines { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string? ShipperName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}

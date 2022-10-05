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
        public int Id { get; set; }

        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string WorkArea { get; set; }
        public string ContactPhone { get; set; }
        public string FullName { get; set; }
        public string ContactMail { get; set; }
        public string CompanyPhoneNumber { get; set; }

        public IList<OrderLineDtoList> OrderLines { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string? ShipperName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string OrderCode { get; set; }


    }
}

using Customerize.Core.DTOs.OrderLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Utilities.Tools
{
    public interface ITools
    {
        decimal OrderTotalAmount(List<OrderLineDtoInsert> list);
    }
}

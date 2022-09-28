using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.DTOs.DashBoard
{
    public class DashBoardDtoDetail
    {
        public int AdvertisementCount { get; set; }
        public int OrdersCount { get; set; }
        public int NewProductCount { get; set; }
        public int WaitingOrderCount { get; set; }
    }
}

using Customerize.Core.DTOs.OrderLine;
using Customerize.Core.Utilities.Tools;

namespace Customerize.Service.Tools.Utilities
{

    public class Tools : ITools
    {
        public decimal OrderTotalAmount(List<OrderLineDtoInsert> list)
        {
            decimal amount = 0;
            foreach (var item in list)
            {
                decimal totalPrice;
                totalPrice = Convert.ToDecimal(item.Price) * item.ProductPiece;
                amount = amount + totalPrice;
            }
            return amount;
        }
    }
}


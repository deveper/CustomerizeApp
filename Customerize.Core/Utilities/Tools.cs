
using Customerize.Core.DTOs.OrderLine;

namespace Customerize.Core.Utilities
{

    public class Tools
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


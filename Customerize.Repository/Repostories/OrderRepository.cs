using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Repository.Repostories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Order> GetByIdOrder(int Id)
        {
            var order = await _context.Orders
                .Include(x => x.Company)
                .Include(x => x.AppUser)
                .Include(x => x.OrderLines)
                   .ThenInclude(x => x.Product)
                .Include(x => x.Shipper)
                .Include(x => x.OrderStatus)
                .FirstOrDefaultAsync(x => x.Id == Id);
            return order;
        }

        public async Task<List<Order>> GetFullOrder()
        {
            var fullOrder = await _context.Orders
                .Include(x => x.AppUser)
                .Include(x => x.Shipper)
                .Include(x => x.Company)
                .ToListAsync();
            return fullOrder;
        }
    }
}

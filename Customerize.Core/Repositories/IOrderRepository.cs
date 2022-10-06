using Customerize.Core.Entities;

namespace Customerize.Core.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetFullOrder();
        Task<Order> GetByIdOrder(int Id);

    }
}

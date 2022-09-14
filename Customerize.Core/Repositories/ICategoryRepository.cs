using Customerize.Core.Entities;

namespace Customerize.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoryWithProduct();
        Task<Category> GetCategoryWithProduct(int id);
    }
}

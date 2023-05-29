using Customerize.Core.Entities;

namespace Customerize.Core.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<List<Company>> GetFullCompany();
    }
}

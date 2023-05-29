using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Customerize.Repository.Repostories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Company>> GetFullCompany()
        {
            var fullCompany = await _context.Companies
                .ToListAsync();
            return fullCompany;
        }
    }
}

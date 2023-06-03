using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Customerize.Repository.Repostories
{
    public class WorkAreaRepository : GenericRepository<WorkArea>, IWorkAreaRepository
    {
        public WorkAreaRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<WorkArea>> GetAllWorkAreas()
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkArea>> GetFullWorkAreas()
        {
            var fullCompany = await _context.WorkAreas
                .ToListAsync();
            return fullCompany;
        }
    }
}

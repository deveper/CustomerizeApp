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


        public async Task<List<WorkArea>> GetAllWorkAreas()
        {
            var allWorkAreas = await _context.WorkAreas
                .ToListAsync();
            return allWorkAreas;
        }
    }
}

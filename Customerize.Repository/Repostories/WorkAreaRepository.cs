using Customerize.Core.DTOs.WorkArea;
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

        public async Task<WorkAreaDtoList?> GetWorkAreaDetail(int workAreaId)
        {
            var workAreaDetail = await _context.WorkAreas
                .FirstOrDefaultAsync(x => x.Id == workAreaId);
            if (workAreaDetail != null)
            {
                var workAreaDetailDto = new WorkAreaDtoList()
                {
                    Id = workAreaDetail.Id,
                    Name = workAreaDetail.Name,
                    isInternal = workAreaDetail.isInternal
                };
                return workAreaDetailDto;
            }
            return new WorkAreaDtoList();
        }

    }
}

using Customerize.Core.DTOs.WorkArea;
using Customerize.Core.Entities;

namespace Customerize.Core.Repositories
{
    public interface IWorkAreaRepository:IGenericRepository<WorkArea>
    {
        Task<List<WorkArea>> GetAllWorkAreas();
        Task<WorkAreaDtoList?> GetWorkAreaDetail(int workAreaId);
    }
}

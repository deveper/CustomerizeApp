using Customerize.Core.Entities;

namespace Customerize.Core.Repositories
{
    public interface IWorkAreaRepository:IGenericRepository<WorkArea>
    {
        Task<List<WorkArea>> GetAllWorkAreas();

    }
}

using Common.Dtos;
using Customerize.Common.Dtos;
using Customerize.Core.DTOs.WorkArea;
using Customerize.Core.Entities;

namespace Customerize.Core.Services
{
    public interface IWorkAreaService : IService<WorkArea>
    {
        Task<ResultDto<IEnumerable<WorkAreaDtoList>>> GetWorkAreaAllDetail();
        Task<ResultDto> Create(WorkAreaDtoInsert input);

        Task<ResultDto<WorkAreaDtoList>> GetWorkAreaDetail(int workAreaId);

    }
}

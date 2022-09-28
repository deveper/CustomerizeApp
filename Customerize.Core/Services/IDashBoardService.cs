using Common.Dtos;
using Customerize.Core.DTOs.DashBoard;

namespace Customerize.Core.Services
{
    public interface IDashBoardService
    {
        Task<ResultDto<DashBoardDtoDetail>> Dailygeneral();
    }
}

using Common.Dtos;
using Customerize.Common.Dtos;
using Customerize.Core.DTOs.Company;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;

namespace Customerize.Core.Services
{
    public interface ICompanyService : IService<Company>
    {
        Task<ResultDto<IEnumerable<CompanyDtoList>>> GetCompanyAllDetail();
        Task<ResultDto<IList<CompanyDtoRemoveRange>>> RemoveRangeCompany(IList<CompanyDtoRemoveRange> input);
        Task<ResultDto> Create(CompanyDtoInsert input);
        ResultDto<List<CompanyDtoList>> GetAllCompanyForDataTable(DataTableModel input);

    }
}

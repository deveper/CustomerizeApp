using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Common.Dtos;
using Customerize.Core.DTOs.WorkArea;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;
using Customerize.Repository.Repostories;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace Customerize.Service.Services
{
    public class WorkAreaService : Service<WorkArea>, IWorkAreaService
    {
        private readonly IWorkAreaRepository _workAreaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public WorkAreaService(IGenericRepository<WorkArea> repository, IUnitOfWork unitOfWork, IWorkAreaRepository workAreaRepository, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _workAreaRepository = workAreaRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<ResultDto<IEnumerable<WorkAreaDtoList>>> GetWorkAreaAllDetail()
        {
            var workAreas = await _workAreaRepository.GetAllWorkAreas();
            if (workAreas != null)
            {
                var map = _mapper.Map<IEnumerable<WorkAreaDtoList>>(workAreas);
                return new ResultDto<IEnumerable<WorkAreaDtoList>>()
                {
                    Data = map,
                    IsSuccess = true,
                    Message = ResultMessages.ProductsAllDetail
                };
            }
            return new ResultDto<IEnumerable<WorkAreaDtoList>>()
            {
                IsSuccess = false,
                Message = ResultMessages.NotFoundProducts
            };
        }

        async public Task<ResultDto> Create(WorkAreaDtoInsert input)
        {
            if (input != null)
            {
                var model = new WorkArea()
                {
                    Name = input.Name,
                    isInternal = input.isInternal,
                };
                await _workAreaRepository.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "Ekleme işlemi başarılı"
                };

            }
            return new ResultDto()
            {
                IsSuccess = false,
                Message = "Ekleme işlemi başarısız"
            };
        }

        ResultDto<List<WorkAreaDtoList>> IWorkAreaService.GetAllWorkAreaForDataTable(DataTableModel input)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Common.Dtos;
using Customerize.Core.DTOs.Category;
using Customerize.Core.DTOs.Company;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;
using Customerize.Repository.Repostories;
using System.Reflection.Metadata.Ecma335;

namespace Customerize.Service.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<CompanyDocument> _productDocumentRepository;


        public CompanyService(IGenericRepository<Company> repository, IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IMapper mapper, IGenericRepository<CompanyDocument> productDocumentRepository) : base(repository, unitOfWork, mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productDocumentRepository = productDocumentRepository;
        }


        public async Task<ResultDto<IEnumerable<CompanyDtoList>>> GetCompanyAllDetail()
        {
            var products = await _companyRepository.GetFullCompany();
            if (products != null)
            {
                var map = _mapper.Map<IEnumerable<CompanyDtoList>>(products);
                return new ResultDto<IEnumerable<CompanyDtoList>>()
                {
                    Data = map,
                    IsSuccess = true,
                    Message = ResultMessages.ProductsAllDetail
                };
            }
            return new ResultDto<IEnumerable<CompanyDtoList>>()
            {
                IsSuccess = false,
                Message = ResultMessages.NotFoundProducts
            };
        }

        async public Task<ResultDto> Create(CompanyDtoInsert input)
        {
            if (input != null)
            {
                var model = new Company()
                {
                    Name = input.Name,
                    Adress = input.Adress,
                    TaxNumber = input.TaxNumber,
                    WorkArea = input.WorkArea,
                };
                await _companyRepository.AddAsync(model);
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

        public Task<ResultDto> Create(ProductDtoInsert input)
        {
            throw new NotImplementedException();
        }

        public ResultDto<List<CompanyDtoList>> GetAllCompanyForDataTable(DataTableModel input)
        {
            throw new NotImplementedException();
        }

        public ResultDto<List<CompanyDtoList>> GetAllProductForDataTable(DataTableModel input)
        {
            throw new NotImplementedException();
        }



        public Task<ResultDto<IList<CompanyDtoRemoveRange>>> RemoveRangeCompany(IList<CompanyDtoRemoveRange> input)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDto<IList<ProductDtoRemoveRange>>> RemoveRangeProduct(IList<ProductDtoRemoveRange> input)
        {
            throw new NotImplementedException();
        }
    }
}

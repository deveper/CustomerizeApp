using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;

namespace Customerize.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepositroy _productRepositroy;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepositroy productRepository, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _productRepositroy = productRepository;
            _mapper = mapper;
        }



        public async Task<ResultDto<IEnumerable<ProductDtoList>>> GetProductAllDetail()
        {
            var products = await _productRepositroy.GetFullProduct();
            if (products != null)
            {
                var map = _mapper.Map<IEnumerable<ProductDtoList>>(products);
                return new ResultDto<IEnumerable<ProductDtoList>>()
                {
                    Data = map,
                    IsSuccess = true,
                    Message = ResultMessages.ProductsAllDetail
                };
            }
            return new ResultDto<IEnumerable<ProductDtoList>>()
            {
                IsSuccess = false,
                Message = ResultMessages.NotFoundProducts
            };
        }
    }
}

using AutoMapper;
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
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepositroy productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepositroy = productRepository;
            _mapper = mapper;
        }

      

        public async Task<List<ProductDtoList>> GetFullProduct()
        {
            var products = await _productRepositroy.GetFullProduct();
          
                var mapperProducts = _mapper.Map<List<ProductDtoList>>(products);
                return mapperProducts;
           
          
        }
    }
}

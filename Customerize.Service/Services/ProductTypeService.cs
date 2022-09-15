using AutoMapper;
using Customerize.Core.DTOs.ProductType;
using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Service.Services
{
    public class ProductTypeService : Service<ProductType>, IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;
        public ProductTypeService(IGenericRepository<ProductType> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductTypeRepository productTypeRepository) : base(repository, unitOfWork, mapper)
        {
            _mapper = mapper;
            _productTypeRepository = productTypeRepository;
        }

        public async Task<List<ProductTypeDtoList>> GetAllProductType()
        {
            var productTtypes = await _productTypeRepository.GetAllProductType();
            var mapperProductTypes = _mapper.Map<List<ProductTypeDtoList>>(productTtypes);
            return mapperProductTypes;
        }
    }
}

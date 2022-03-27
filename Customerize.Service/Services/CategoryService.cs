using AutoMapper;
using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;

namespace Customerize.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDtoWithProductList>> GetCategoryWithProduct()
        {
            var categories = await _categoryRepository.GetCategoryWithProduct();
            var mapperCategories = _mapper.Map<List<CategoryDtoWithProductList>>(categories);
            return mapperCategories;
        }

        public async Task<Category> GetCategoryWithProduct(int id)
        {
            var category = await _categoryRepository.GetCategoryWithProduct(id);
            return category;
        }
    }

}

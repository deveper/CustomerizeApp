using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Customerize.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> GetCategoryById(int Id)
        {
            var category = await _categoryRepository.GetByIdAsync(Id);
            if (category != null)
            {
                var mappedCategory = _mapper.Map<CategoryDto>(category);
                return mappedCategory;

            }
            else
            {
                //ToDo:Error messages
                return null;
            }
        }

        public async Task<List<CategoryDtoWithProductList>> GetCategoryWithProduct()
        {
            var categories = await _categoryRepository.GetCategoryWithProduct();
            var mappedCategories = _mapper.Map<List<CategoryDtoWithProductList>>(categories);
            return mappedCategories;
        }

        public async Task<CategoryDtoWithProductList> GetCategoryWithProductId(int id)
        {
            var category = await _categoryRepository.GetCategoryWithProductId(id);
            var mappedCategories = _mapper.Map<CategoryDtoWithProductList>(category);
            return mappedCategories;
        }

        public async Task<ResultDto> UpdateCategory(CategoryDtoUpdate input)
        {
            var category = await _categoryRepository.GetByIdAsync(input.Id);
            try
            {
                if (category != null)
                {

                    category.Name = input.Name;
                    _categoryRepository.Update(category);
                    await _unitOfWork.CommitAsync();

                    return new ResultDto()
                    {
                        IsSuccess = true,
                        Message = ResultMessages.CategoryUpdate
                    };
                }
                else
                {

                }

            }
            catch (Exception e)
            {

            }
            return new ResultDto()
            {
                IsSuccess = false,
                Message = ResultMessages.NotFoundCategory
            };
        }
    }

}

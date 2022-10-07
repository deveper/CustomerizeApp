using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Common.Dtos;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, unitOfWork, mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ResultDto<List<CategoryDtoList>> GetAllCategoryForDataTable(DataTableModel input)
        {
            var categories = _categoryRepository.GetAll();
            if (categories != null)
            {
                if (!(string.IsNullOrEmpty(input.SortColumn) && string.IsNullOrEmpty(input.SortColumnDirection)))
                {

                    categories = input.SortColumnDirection == "asc" ? categories.OrderBy(x => input.SortColumn) : categories.OrderByDescending(x => input.SortColumn);
                    switch (input.SortColumn)
                    {
                        case "Id":
                            categories = input.SortColumnDirection == "asc" ? categories.OrderBy(x => x.Id) : categories.OrderByDescending(x => x.Id);
                            break;
                        case "CreatedDate":
                            categories = input.SortColumnDirection == "asc" ? categories.OrderBy(x => x.CreatedDate) : categories.OrderByDescending(x => x.CreatedDate);
                            break;
                        case "Code":
                            categories = input.SortColumnDirection == "asc" ? categories.OrderBy(x => x.Code) : categories.OrderByDescending(x => x.Code);
                            break;
                        case "Name":
                            categories = input.SortColumnDirection == "asc" ? categories.OrderBy(x => x.Name) : categories.OrderByDescending(x => x.Name);
                            break;

                    }
                }
                if (!string.IsNullOrEmpty(input.SsearchValue))
                {
                    categories = categories.Where(x => x.Name.Contains(input.SsearchValue));
                }
                var map = _mapper.Map<List<CategoryDtoList>>(categories);
                var data = map.Skip(input.Skip).Take(input.PageSize);
                var recordsTotal = map.Count();

                return new ResultDto<List<CategoryDtoList>>()
                {
                    Data = data.ToList(),
                    IsSuccess = true,
                    Message = ResultMessages.GeneralSuccess,
                    Total = recordsTotal,
                    Req = input.Draw

                };
            }
            return new ResultDto<List<CategoryDtoList>>()
            {
                IsSuccess = false,
                Message = ResultMessages.GeneralErrorMessage,
                Total = 0,
            };

        }

        public async Task<ResultDto<CategoryDtoUpdate>> GetCategoryById(int Id)
        {
            var category = await _categoryRepository.GetByIdAsync(Id);

            if (category != null)
            {
                var map = _mapper.Map<CategoryDtoUpdate>(category);
                return new ResultDto<CategoryDtoUpdate>()
                {
                    Data = map,
                    IsSuccess = true,
                    Message = ResultMessages.CategoryFound
                };

            }
            else
            {
                return new ResultDto<CategoryDtoUpdate>()
                {
                    IsSuccess = false,
                    Message = ResultMessages.NotFoundCategory
                };
            }
        }

        public async Task<IEnumerable<CategoryDtoWithProductList>> GetCategoryWithProduct()
        {
            var categories = await _categoryRepository.GetCategoryWithProduct();
            var mappedCategories = _mapper.Map<IEnumerable<CategoryDtoWithProductList>>(categories);
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
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = ResultMessages.NotFoundCategory
                    };

                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

}

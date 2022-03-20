using AutoMapper;
using Customerize.Core.DTOs.Category;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<Category> _categoryService;

        public CategoryController(IMapper mapper, IService<Category> categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        #region CategoryEdit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = _categoryService.Where(x => x.Id == id).Result.FirstOrDefault();
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return View(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDtoUpdate model)
        {
            var category = _categoryService.Where(x => x.Id == model.Id).Result.FirstOrDefault();
            category.Name = model.Name;
            category.UpdatedDate = DateTime.Now;
            _categoryService.UpdateAsync(category);
            return View(_mapper.Map<CategoryDto>(category));
        }
        #endregion

        #region CategoryCreate
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDtoInsert model)
        {
            var mappedCategory = _mapper.Map<Category>(model);
            var insertCategory = await _categoryService.AddAsync(mappedCategory);
            return View();
        }

        #endregion

        #region CategoryList
        public async Task<IActionResult> GetAllList()
        {
            return View(_mapper.Map<IEnumerable<CategoryDtoList>>(await _categoryService.GetAllAsync()));
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}

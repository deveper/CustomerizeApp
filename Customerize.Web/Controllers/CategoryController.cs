using AutoMapper;
using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService1;

        public CategoryController(IMapper mapper, IService<Category> categoryService, ICategoryService categoryService1)
        {
            _mapper = mapper;
            _categoryService1 = categoryService1;
        }

        #region CategoryEdit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = _categoryService1.Where(x => x.Id == id).Result.FirstOrDefault();
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return View(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDtoUpdate model)
        {
            var category = _categoryService1.Where(x => x.Id == model.Id).Result.FirstOrDefault();
            if (model.Name != null)
            {
                category.Name = model.Name;
                category.UpdatedDate = DateTime.Now;
                _categoryService1.UpdateAsync(category);
                return RedirectToAction("GetAllList");
            }
            var model1 = new CategoryDto
            {
                Id = model.Id,
                Name = category.Name
            };
            //var mappedCategory = _mapper.Map<Category>(model);
            //_categoryService.UpdateAsync(mappedCategory);
            return View("Edit", model1);
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
            var insertCategory = await _categoryService1.AddAsync(mappedCategory);
            return RedirectToAction("GetAllList");
        }

        #endregion

        #region CategoryList
        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var categoryList = await _categoryService1.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDtoList>>(categoryList));
        }
        #endregion

        #region CategoyListWithProduct
        [HttpGet]
        public async Task<IActionResult> GetCategoryListWithProduct()
        {
            var categorylistWithProduct = await _categoryService1.GetCategoryWithProduct();
            return View(categorylistWithProduct);
        }
        #endregion

        #region CategoryRemove
        public async Task<IActionResult> Remove(int id)
        {

            var category = await _categoryService1.GetCategoryWithProduct(id);
            _categoryService1.RemoveAsync(category);
            return RedirectToAction("GetCategoryListWithProduct");



        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}

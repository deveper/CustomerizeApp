using AutoMapper;
using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class CategoryController : Controller
    {
        #region DI
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService1;
        #endregion

        public CategoryController(IMapper mapper, IService<Category> categoryService, ICategoryService categoryService1)
        {
            _mapper = mapper;
            _categoryService1 = categoryService1;
        }

        #region CategoryEdit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _categoryService1.GetCategoryById(id);
            var map = _mapper.Map<CategoryDtoUpdate>(result);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDtoUpdate model)
        {
            var result = await _categoryService1.UpdateCategory(model);
            if (result.IsSuccess = true)
            {
                return Json(result.Message);
            }
            return Json(result.Message);

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

            //var category = await _categoryService1.GetCategoryWithProductId(id);
            //_categoryService1.RemoveAsync()
            //return RedirectToAction("GetCategoryListWithProduct");
            return null;


        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}

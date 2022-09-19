using AutoMapper;
using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace Customerize.Web.Controllers
{
    public class CategoryController : Controller
    {
        #region DI
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        #endregion

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        #region CategoryEdit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _categoryService.GetCategoryById(id);
            if (result.IsSuccess)
            {
                return View(result.Data);
            }
            return Json(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDtoUpdate model)
        {
            var result = await _categoryService.UpdateCategory(model);
            if (result.IsSuccess)
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
            var map = _mapper.Map<Category>(model);
            var result = await _categoryService.AddAsync(map);
            if (result.IsSuccess)
            {
                return Json(result.Message);
            }
            //ToDo ErrorControl
            return Json(result.Message);
        }

        #endregion

        #region CategoryList
        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var result = await _categoryService.GetAllAsync();
            var map = _mapper.Map<IEnumerable<CategoryDtoList>>(result);
            return View(map);
        }
        #endregion

        #region CategoyListWithProduct
        [HttpGet]
        public async Task<IActionResult> GetCategoryListWithProduct()
        {
            var result = await _categoryService.GetCategoryWithProduct();
            return View(result);
        }
        #endregion

        #region CategoryRemove
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {

            #region :)
            var category = await _categoryService.GetByIdAsync(id);
            var result = await _categoryService.RemoveAsync(category.Data);
            #endregion
            if (result.IsSuccess)
            {
                return Json(result.Message);
            }
            //ToDo ErrorControl
            return Json(result.Message);


        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}

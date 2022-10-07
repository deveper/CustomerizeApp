using AutoMapper;
using Customerize.Common.Dtos;
using Customerize.Core.DTOs.Category;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IActionResult> CategoryList()
        {
            var dataTableModel = new DataTableModel()
            {
                Draw = Request.Form["draw"].FirstOrDefault(),
                Start = Request.Form["start"].FirstOrDefault(),
                Length = Request.Form["length"].FirstOrDefault(),
                SortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(),
                SortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault(),
                SsearchValue = Request.Form["search[value]"].FirstOrDefault(),
                PageSize = Request.Form["length"].FirstOrDefault() != null ? Convert.ToInt32(Request.Form["length"].FirstOrDefault()) : 0,
                Skip = Request.Form["start"].FirstOrDefault() != null ? Convert.ToInt32(Request.Form["start"].FirstOrDefault()) : 0,
                RecordsTotal = 0
            };

            var result = _categoryService.GetAllCategoryForDataTable(dataTableModel);
            var jsondata = new { draw = result.Req, recordsfiltered = result.Total, recordstotal = result.Total, data = result.Data };

            //var map = _mapper.Map<IEnumerable<CategoryDtoList>>(result.Data);
            //var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = new ActivityDto() };

            //return Ok(jsonData);
            return Ok(jsondata);
        }

        #region CategoryList
        public async Task<IActionResult> GetAllList()
        {
            return View();
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

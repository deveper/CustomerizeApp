using AutoMapper;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Customerize.Web.Controllers
{
    public class ProductController : Controller
    {
        #region DI
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductTypeService _productTypeService;
        #endregion
        public ProductController(IMapper mapper, IProductService productService, ICategoryService categoryService, IProductTypeService productTypeService)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
            _productTypeService = productTypeService;
        }
        #region ProductList
        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var result = await _productService.GetProductAllDetail();
            return View(result.Data);
        }
        #endregion

        #region ProductCreate
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var productTypes = await _productTypeService.GetAllAsync();
            ViewBag.productTypes = new SelectList(productTypes.Data, "Id", "Name");

            var categories = await _categoryService.GetAllAsync();
            ViewBag.categories = new SelectList(categories.Data, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDtoInsert model)
        {

            var map = _mapper.Map<Product>(model);
            var result = await _productService.Create(model);
            if (result.IsSuccess)
            {
                return Json(result.Message);
            }
            return Json(result.Message);
        }
        #endregion

        #region Product Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var result = await _productService.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                var productTypes = await _productTypeService.GetAllProductType();
                ViewBag.productTypes = new SelectList(productTypes, "Id", "Name");

                var categories = await _categoryService.GetAllAsync();
                ViewBag.categories = new SelectList(categories.Data, "Id", "Name");

                var productDto = _mapper.Map<ProductDtoUpdate>(result.Data);
                return View(productDto);
            }
            return RedirectToAction("GetAllList");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDtoUpdate model)
        {
            var map = _mapper.Map<Product>(model);
            var result = await _productService.UpdateAsync(map);
            if (result.IsSuccess)
            {
                return Json(result.Message);
            }
            return RedirectToAction("Edit");
        }
        #endregion

        #region Product Remove

        [HttpPost]
        public async Task<IActionResult> Remove(int Id)
        {
            #region :)
            var product = await _productService.GetByIdAsync(Id);
            var result = await _productService.RemoveAsync(product.Data);
            #endregion
            if (result.IsSuccess)
            {
                return Json(result.Message);
            }
            return Json(result.Message);

        }
        #endregion

        #region ProductRemoveRange

        [HttpGet]
        public async Task<IActionResult> RemoveRange()
        {
            var productList = await _productService.GetProductAllDetail();
            if (productList.Data == null)
            {
                return View();
            }
            var map = _mapper.Map<IList<ProductDtoRemoveRange>>(productList.Data);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRangeConfirm(IList<ProductDtoRemoveRange> model)
        {
            var result = await _productService.RemoveRangeProduct(model);
            string jsonString = System.Text.Json.JsonSerializer.Serialize(result);

            if (result.IsSuccess)
            {
                return Json(jsonString);
            }
            return RedirectToAction("RemoveRange");
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}

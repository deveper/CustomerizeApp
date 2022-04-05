using AutoMapper;
using Customerize.Core.DTOs.Category;
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
        private readonly IProductService _productService1;
        private readonly ICategoryService _categoryService;
        private readonly IProductTypeService _productTypeService;
        #endregion
        public ProductController(IMapper mapper, IService<Product> service, IProductService productService1, ICategoryService categoryService, IProductTypeService productTypeService)
        {
            _mapper = mapper;
            _productService1 = productService1;
            _categoryService = categoryService;
            _productTypeService = productTypeService;
        }
        #region ProductList
        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var productList = await _productService1.GetFullProduct();
            return View(/*_mapper.Map<IEnumerable<ProductDtoList>>(productList)*/productList);
        }
        #endregion

        #region ProductInsert
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var productTypes = await _productTypeService.GetAllProductType();
            ViewBag.productTypes = new SelectList(productTypes, "Id", "Name");

            var categories = await _categoryService.GetAllAsync();
            var categoryMapper = _mapper.Map<List<CategoryDtoList>>(categories);
            ViewBag.categories = new SelectList(categoryMapper, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDtoInsert model)
        {
            var result = await _productService1.AnyAsync(x => x.Name == model.Name);
            if (result == false)
            {
                var productTypes = await _productTypeService.GetAllProductType();
                ViewBag.productTypes = new SelectList(productTypes, "Id", "Name");
                var categories = await _categoryService.GetAllAsync();
                var categoryMapper = _mapper.Map<List<CategoryDtoList>>(categories);
                ViewBag.categories = new SelectList(categoryMapper, "Id", "Name");

                var mappedProduct = _mapper.Map<Product>(model);
                var insertProduct = await _productService1.AddAsync(mappedProduct);
                return RedirectToAction("GetAllList");
            }

            return RedirectToAction("Create");
        }
        #endregion

        #region Product Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = _productService1.Where(x => x.Id == id).Result.FirstOrDefault();
            if (product != null)
            {
                var productTypes = await _productTypeService.GetAllProductType();
                ViewBag.productTypes = new SelectList(productTypes, "Id", "Name");

                var categories = await _categoryService.GetAllAsync();
                var categoryMapper = _mapper.Map<List<CategoryDtoList>>(categories);
                ViewBag.categories = new SelectList(categoryMapper, "Id", "Name");
                var productDto = _mapper.Map<ProductDtoUpdate>(product);
                return View(productDto);
            }
            return RedirectToAction("GetAllList");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDtoUpdate model)
        {
            var product =  _productService1.Where(x => x.Id == model.Id).Result.FirstOrDefault();
            if (product!=null)
            {
                var mapperdProduct = _mapper.Map<Product>(model);
                mapperdProduct.UpdatedDate = DateTime.Now;
                await _productService1.UpdateAsync(mapperdProduct);
                return RedirectToAction("GetAllList");
            }
            return RedirectToAction("Edit");
        }
        #endregion

        #region Product Remove
        public async Task<IActionResult> Remove(int id)
        {
            var result = _productService1.Where(x => x.Id == id).Result.FirstOrDefault();
            if (result != null)
            {
                _productService1.RemoveAsync(result);
                return RedirectToAction("GetAllList");
            }
            //ToDo:Need Message
            return null;

        }
        #endregion

        #region ProductRemoveRange

        [HttpGet]
        public async Task<IActionResult> RemoveRange()
        {
            var productList = await _productService1.GetFullProduct();
            var map = _mapper.Map<List<ProductDtoRemoveRange>>(productList);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRange(List<ProductDtoRemoveRange> model)
        {
            List<Product> products = new List<Product>();
            foreach (var product in model)
            {
                if (product.DeleteProducts.Selected)
                {
                    var selectedProduct = _productService1.Where(x => x.Id == product.Id).Result.First();
                    products.Add(selectedProduct);
                }
            }
            await _productService1.RemoveRangeAsync(products);
            return View("RemoveRange");
        } 
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}

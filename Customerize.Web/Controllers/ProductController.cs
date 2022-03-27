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
        private readonly IMapper _mapper;
        private readonly IService<Product> _prodcutService;
        private readonly IProductService _productService1;
        private readonly ICategoryService _categoryService;
        public ProductController(IMapper mapper, IService<Product> service, IProductService productService1, ICategoryService categoryService)
        {
            _mapper = mapper;
            _prodcutService = service;
            _productService1 = productService1;
            _categoryService = categoryService;
        }
        #region ProductList
        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var productList = await _productService1.GetFullProduct();
            return View(_mapper.Map<IEnumerable<ProductDtoList>>(productList));
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryMapper = _mapper.Map<List<CategoryDtoList>>(categories);
            ViewBag.categories = new SelectList(categoryMapper, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDtoInsert model)
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryMapper = _mapper.Map<List<CategoryDtoList>>(categories);
            ViewBag.categories = new SelectList(categoryMapper, "Id", "Name");

            var mappedProduct = _mapper.Map<Product>(model);
            var insertProduct = await _productService1.AddAsync(mappedProduct);
            return RedirectToAction("GetAllList");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

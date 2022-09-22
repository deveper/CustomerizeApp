using AutoMapper;
using Customerize.Core.DTOs.Order;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public OrderController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var products = await _productService.GetAllAsync();
            var map = _mapper.Map<List<ProductDtoList>>(products);
            var model = new OrderDtoInsert()
            {
                Products = map
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string model)
        {
            return Json("boş");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

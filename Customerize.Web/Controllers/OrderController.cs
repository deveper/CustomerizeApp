using AutoMapper;
using Customerize.Core.DTOs.Order;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        public OrderController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var products = await _productService.GetProductAllDetail();
            return View(new OrderDtoInsert() { Products = products.Data.ToList() });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDtoInsert model)
        {
            var result = await _orderService.Create(model);
            if (result.IsSuccess)
            {
                return Json(result.Message);
            }
            return Json(result.Message);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

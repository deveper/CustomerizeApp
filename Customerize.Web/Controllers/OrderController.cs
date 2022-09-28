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
        private readonly IMapper _mapper;
        public OrderController(IProductService productService, IOrderService orderService, IMapper mapper)
        {
            _productService = productService;
            _orderService = orderService;
            _mapper = mapper;
        }
        #region OrderCreate
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
        #endregion

        #region GetAllList

        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var result = await _orderService.GetAllAsync();
            var map = _mapper.Map<IEnumerable<OrderDtoList>>(result.Data);
            return View(map);
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}

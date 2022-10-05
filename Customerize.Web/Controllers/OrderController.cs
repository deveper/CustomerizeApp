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
            var result = await _productService.GetProductAllDetail();
            if (result.IsSuccess)
            {
                return View(new OrderDtoInsert() { Products = result.Data.ToList() });
            }
            return Json(result.Message);

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
            var result = await _orderService.GetOrders();
            return View(result.Data.ToList());
        }
        #endregion

        #region OrderDetailById
        [HttpGet]
        public async Task<IActionResult> OrderDetail(int Id)
        {
            var result = await _orderService.GetByIdOrderDetails(Id);
            if (result.IsSuccess)
            {
                return View(result.Data);
            }
            return Json(result.Message);
        }
        #endregion
        #region Invoice Order
        public async Task<IActionResult> InvoicePrint(int Id)
        {
            var result = await _orderService.GetByIdOrderDetails(Id);
            if (result.IsSuccess)
            {
                return View(result.Data);
            }

            return Json(result.Message);
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}

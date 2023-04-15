using AutoMapper;
using Customerize.Common.Dtos;
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

        #region DataTableFunction
        public async Task<IActionResult> ProductList()
        {
            #region DataTableModel
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
            #endregion
            var result = _productService.GetAllProductForDataTable(dataTableModel);
            if (result.IsSuccess)
            {
                return Json(new { draw = result.Req, recordsfiltered = result.Total, recordstotal = result.Total, data = result.Data });
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

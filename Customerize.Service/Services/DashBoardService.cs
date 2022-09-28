using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Common.StaticClasses;
using Customerize.Core.DTOs.DashBoard;
using Customerize.Core.Entities;
using Customerize.Core.Services;

namespace Customerize.Service.Services
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IService<Product> _productService;
        private readonly IService<Order> _orderService;
        private readonly IService<Advertisement> _advertiserService;
        public DashBoardService(IProductService productService, IOrderService orderService, IService<Advertisement> advertiserService)
        {
            _productService = productService;
            _orderService = orderService;
            _advertiserService = advertiserService;
        }
        public async Task<ResultDto<DashBoardDtoDetail>> Dailygeneral()
        {
            var MyDate = DateTime.Now;

            var orders = await _orderService.WhereList(x => x.CreatedDate.Date == MyDate.Date);
            var ordersWaiting = await _orderService.WhereList(x => x.CreatedDate.Date == MyDate.Date && x.OrderStatusId == OrderStatuses.Beklemede);
            var newProduct = await _productService.WhereList(x => x.CreatedDate.Date == MyDate.Date);
            var newAdvertisement = await _advertiserService.WhereList(x => x.CreatedDate.Date == MyDate.Date);
            var ordersCount = orders.Count();
            var newProductCount = newProduct.Count();
            var newAdvertisementCount = newAdvertisement.Count();
            var ordersWaitingCount = ordersWaiting.Count();
            if (ordersCount > 0 || newProductCount > 0 || newAdvertisementCount > 0)
            {
                return new ResultDto<DashBoardDtoDetail>()
                {
                    Data = new DashBoardDtoDetail()
                    {
                        OrdersCount = ordersCount,
                        NewProductCount = newProductCount,
                        AdvertisementCount = newAdvertisementCount,
                        WaitingOrderCount = ordersWaitingCount,
                    },
                    IsSuccess = true,
                    Message = ResultMessages.GeneralSuccess
                };
            }
            return new ResultDto<DashBoardDtoDetail>()
            {
                IsSuccess = false,
                Message = ResultMessages.GeneralErrorMessage
            };
        }

        //
    }
}

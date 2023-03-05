using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Common.StaticClasses;
using Customerize.Core.DTOs.Order;
using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;
using Customerize.Core.Utilities;
using Customerize.Core.Utilities.Tools;
using Customerize.Repository;
using Customerize.Service.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;
using System.Xml.Schema;

namespace Customerize.Service.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IGenericRepository<OrderLine> _orderLineRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IGenericRepository<Product> _productReposistory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ITools _tools;
        public OrderService(IGenericRepository<OrderLine> orderLineRepository, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Order> repository, IOrderRepository orderRepository, IGenericRepository<Product> productReposistory, AppDbContext context, ITools tools) : base(repository, unitOfWork, mapper)
        {
            _orderLineRepository = orderLineRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
            _orderRepository = orderRepository;
            _productReposistory = productReposistory;
            _context = context;
            _tools = tools;
        }
        public async Task<ResultDto> Create(OrderDtoInsert input)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var orderAmount = _tools.OrderTotalAmount(input.OrderLines);

                var order = new Order()
                {
                    UserId = input.UserId,
                    CompanyId = input.CompanyId,
                    OrderStatusId = OrderStatuses.Beklemede,
                    ContactMail = input.ContactMail,
                    ContactPhone = input.ContactPhone,
                    Description = input.Description,
                    Amount = orderAmount
                };

                await _repository.AddAsync(order);
                await _unitOfWork.CommitAsync();

                var orderlines = new List<OrderLine>();
                orderlines.AddRange(input.OrderLines.Select(x => new OrderLine
                {
                    OrderId = order.Id,
                    ProductId = x.ProductId,
                    ProductPiece = x.ProductPiece,
                    LineAmount = Convert.ToDecimal(x.Price) * x.ProductPiece
                }));

                await _orderLineRepository.AddRangeAsync(orderlines);
                var succes = await _unitOfWork.CommitAsync();

                transaction.Commit();

                if (succes)
                {
                    List<Product> updatedProducts = input.OrderLines.Select(x => new Product()
                    {
                        Id = x.ProductId,
                        Name = x.Name,
                        Price = Decimal.Parse(x.Price),
                        ProductTypeId = x.ProductTypeId,
                        CategoryId = x.CategoryId,
                        Stock = x.LastStock - x.ProductPiece
                    }).ToList();

                    if (updatedProducts != null)
                    {
                        updatedProducts.AddRange(updatedProducts);
                        _productReposistory.UpdateRange(updatedProducts);
                        _unitOfWork.Commit();
                    }
                    return new ResultDto()
                    {
                        IsSuccess = true,
                        Message = ResultMessages.CreateOrder,
                        Total = input.OrderLines.Count,
                    };
                }
            }
            catch
            {
                transaction.Rollback();
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = ResultMessages.GeneralErrorMessage,
                    Total = 0
                };
            }



            return new ResultDto()
            {
                IsSuccess = false,
                Message = ResultMessages.GeneralErrorMessage,
                Total = 0
            };
        }

        public async Task<ResultDto<OrderDtoDetails>> GetByIdOrderDetails(int Id)
        {
            var orders = await _orderRepository.GetByIdOrder(Id);

            if (orders != null)
            {
                var map = _mapper.Map<OrderDtoDetails>(orders);
                return new ResultDto<OrderDtoDetails>()
                {
                    Data = map,
                    IsSuccess = true,
                    Message = ResultMessages.OrderDetail,
                };
            }
            return new ResultDto<OrderDtoDetails>()
            {
                IsSuccess = false,
                Message = ResultMessages.NotFoundOrders,
                Total = 0
            };
        }

        public async Task<ResultDto<IEnumerable<OrderDtoList>>> GetOrders()
        {
            var orders = await _orderRepository.GetFullOrder();
            if (orders != null)
            {
                var map = _mapper.Map<IEnumerable<OrderDtoList>>(orders);
                return new ResultDto<IEnumerable<OrderDtoList>>()
                {
                    Data = map,
                    IsSuccess = true,
                    Message = ResultMessages.OrderSearch,
                    Total = map.Count()
                };
            }
            return new ResultDto<IEnumerable<OrderDtoList>>()
            {
                IsSuccess = false,
                Message = ResultMessages.NotFoundOrders,
                Total = 0
            };

        }
    }
}

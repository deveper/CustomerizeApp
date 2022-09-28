using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Core.DTOs.Order;
using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;
using Customerize.Service.UnitOfWork;

namespace Customerize.Service.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IGenericRepository<OrderLine> _orderLineRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<OrderLine> orderLineRepository, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Order> repository) : base(repository, unitOfWork, mapper)
        {
            _orderLineRepository = orderLineRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ResultDto> Create(OrderDtoInsert input)
        {

            var order = new Order()
            {
                UserId = input.UserId,
                CompanyId = input.CompanyId,
            };
            await _repository.AddAsync(order);
            await _unitOfWork.CommitAsync();

            var orderlines = new List<OrderLine>();
            orderlines.AddRange(input.OrderLines.Select(x => new OrderLine
            {
                OrderId = order.Id,
                ProductId = x.ProductId,
                ProductPiece = x.ProductPiece,
            }));
            await _orderLineRepository.AddRangeAsync(orderlines);

            var succes = await _unitOfWork.CommitAsync();
            if (succes)
            {
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = ResultMessages.CreateOrder,
                    Total = input.OrderLines.Count,
                };
            }

            return new ResultDto()
            {
                IsSuccess = false,
                Message = ResultMessages.GeneralErrorMessage,
                Total = 0
            };
        }
    }
}

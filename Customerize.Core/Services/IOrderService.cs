﻿using Common.Dtos;
using Customerize.Core.DTOs.Order;
using Customerize.Core.Entities;


namespace Customerize.Core.Services
{
    public interface IOrderService : IService<Order>
    {
        Task<ResultDto> Create(OrderDtoInsert input);
    }
}
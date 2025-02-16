using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Models.Orders;

namespace OrderManagementSystem.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Result<OrderVm>> CreateOrder(OrderCreateDto orderCreateDto);
    }
}

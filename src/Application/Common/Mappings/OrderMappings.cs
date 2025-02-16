using OrderManagementSystem.Application.Models.Orders;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Common.Mappings
{
    public static class OrderMappings
    {
        public static OrderVm ToOrderVm(this Order order)
        {
            return new OrderVm
            {
                Id = order.Id,
                Products = new List<OrderProductVm>(order.OrderProducts.Select(x => x.ToOrderProductVm()))
            };
        }

        public static OrderProductVm ToOrderProductVm(this OrderProduct orderProduct)
        {
            return new OrderProductVm
            {
                Id = orderProduct.Id,
                Quantity = orderProduct.Quantity,
                ProductId = orderProduct.ProductId
            };
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderManagementSystem.Application.Common.Interfaces;
using OrderManagementSystem.Application.Common.Mappings;
using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Models.Orders;
using OrderManagementSystem.Application.Services.Interfaces;
using OrderManagementSystem.Application.Validators.Orders;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IApplicationDbContext applicationDbContext, ILogger<OrderService> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<Result<OrderVm>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            OrderCreateDtoValidator validator = new OrderCreateDtoValidator();
            var validationResult = validator.Validate(orderCreateDto);

            if (!validationResult.IsValid)
            {
                return Result<OrderVm>.BadData(validationResult.Errors.Select(x =>
                    new FieldError(x.PropertyName, x.ErrorMessage)));
            }

            using var transaction = await _applicationDbContext.Database.BeginTransactionAsync();

            var order = new Order();
            try
            {
                _applicationDbContext.Orders.Add(order);
                await _applicationDbContext.SaveChangesAsync();

                foreach (var product in orderCreateDto.Products)
                {
                    var orderProduct = new OrderProduct
                    {
                        OrderId = order.Id,
                        ProductId = product.ProductId,
                        Quantity = product.Quantity
                    };
                    _applicationDbContext.OrderProducts.Add(orderProduct);
                    await _applicationDbContext.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return Result<OrderVm>.BadData("Products", "One of the products had an invalid product id.");
            }

            var addedOrder = await _applicationDbContext.Orders
                .AsNoTracking()
                .Include(x => x.OrderProducts)
                .FirstOrDefaultAsync(x => x.Id == order.Id);

            if (addedOrder == null)
            {
                return Result<OrderVm>.NotFound("OrderId", "Created order could not be found");
            }

            return Result<OrderVm>.Success(addedOrder.ToOrderVm());
        }
    }
}

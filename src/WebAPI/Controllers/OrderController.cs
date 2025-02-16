using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Models.Orders;
using OrderManagementSystem.Application.Services.Interfaces;

namespace OrderManagementSystem.WebAPI.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("api/order/")]
        public async Task<ActionResult> CreateOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            Result<OrderVm> result = await _orderService.CreateOrder(orderCreateDto);

            return result.Type switch
            {
                ResultType.Success => Ok(result.Value),
                ResultType.NotFound => NotFound(result.GetErrors()),
                ResultType.BadData => BadRequest(result.GetErrors()),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }
    }
}

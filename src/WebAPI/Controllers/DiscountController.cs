using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Models.Discounts;
using OrderManagementSystem.Application.Services.Interfaces;

namespace OrderManagementSystem.WebAPI.Controllers
{
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("api/discount/")]
        public async Task<ActionResult> CreateDiscount([FromBody] DiscountCreateDto discountCreateDto)
        {
            Result<DiscountVm> result = await _discountService.CreateDiscount(discountCreateDto);

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

using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Models.Discounts;

namespace OrderManagementSystem.Application.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<Result<DiscountVm>> CreateDiscount(DiscountCreateDto discountCreateDto);
    }
}

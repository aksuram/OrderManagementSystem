using OrderManagementSystem.Application.Models.Discounts;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Common.Mappings
{
    public static class DiscountMappings
    {
        public static DiscountVm ToDiscountVm(this Discount discount)
        {
            return new DiscountVm
            {
                Id = discount.Id,
                Percentage = discount.Percentage,
                QuantityThreshold = discount.QuantityThreshold,
                ProductId = discount.ProductId
            };
        }
    }
}

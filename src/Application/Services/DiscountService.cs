using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Application.Common.Interfaces;
using OrderManagementSystem.Application.Common.Mappings;
using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Models.Discounts;
using OrderManagementSystem.Application.Services.Interfaces;
using OrderManagementSystem.Application.Validators.Discounts;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DiscountService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Result<DiscountVm>> CreateDiscount(DiscountCreateDto discountCreateDto)
        {
            DiscountCreateDtoValidator validator = new DiscountCreateDtoValidator();
            var validationResult = validator.Validate(discountCreateDto);

            if (!validationResult.IsValid)
            {
                return Result<DiscountVm>.BadData(validationResult.Errors.Select(x =>
                    new FieldError(x.PropertyName, x.ErrorMessage)));
            }

            var product = await _applicationDbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == discountCreateDto.ProductId);

            if (product == null)
            {
                return Result<DiscountVm>.NotFound("ProductId", "Specified product id could not be found");
            }

            var existingDiscount = await _applicationDbContext.Discounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductId == discountCreateDto.ProductId);

            if (existingDiscount != null)
            {
                return Result<DiscountVm>.BadData("ProductId", "Specified product id already has a discount");
            }

            var discount = new Discount
            {
                Percentage = discountCreateDto.Percentage,
                QuantityThreshold = discountCreateDto.QuantityThreshold ?? 0,
                ProductId = discountCreateDto.ProductId
            };

            _applicationDbContext.Discounts.Add(discount);
            await _applicationDbContext.SaveChangesAsync();

            return Result<DiscountVm>.Success(discount.ToDiscountVm());
        }
    }
}

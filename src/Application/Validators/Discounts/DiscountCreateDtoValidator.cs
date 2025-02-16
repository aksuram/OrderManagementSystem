using FluentValidation;
using OrderManagementSystem.Application.Models.Discounts;

namespace OrderManagementSystem.Application.Validators.Discounts
{
    public class DiscountCreateDtoValidator : AbstractValidator<DiscountCreateDto>
    {
        public DiscountCreateDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.Stop)
                .NotEqual(Guid.Empty)
                .WithMessage("Product's id can not be empty.");

            RuleFor(x => x.Percentage)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0.0m)
                .WithMessage("Discount's percentage can not be negative.")
                .LessThanOrEqualTo(1.0m)
                .WithMessage("Discount's percentage can not exceed 1.0(100%).");

            RuleFor(x => x.QuantityThreshold)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Discount's product quantity threshold can not be negative.")
                .LessThanOrEqualTo(100)
                .WithMessage("Discount's product quantity threshold can not exceed 100.");
        }
    }
}

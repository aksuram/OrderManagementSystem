using FluentValidation;
using OrderManagementSystem.Application.Models.Products;

namespace OrderManagementSystem.Application.Validators.Products
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Product's name can not be empty.")
                .MinimumLength(1)
                .WithMessage("Product's name should have at least one character.")
                .MaximumLength(200)
                .WithMessage("Product's name can not exceed 200 characters.");

            RuleFor(x => x.Price)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0.0m)
                .WithMessage("Product's price can not be negative.");

        }
    }
}

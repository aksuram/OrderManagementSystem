using FluentValidation;
using OrderManagementSystem.Application.Models.Products;

namespace OrderManagementSystem.Application.Validators.Products
{
    public class ProductListDtoValidator : AbstractValidator<ProductListDto>
    {
        public ProductListDtoValidator()
        {
            RuleFor(x => x.Search)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(100)
                .WithMessage("Search parameter can not exceed 100 characters");

            RuleFor(x => x.PageNumber)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage("Page number can not be lower than 1");

            RuleFor(x => x.PageSize)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage("Page size can not be lower than 1")
                .LessThanOrEqualTo(100)
                .WithMessage("Page size can not exceed 100");
        }
    }
}

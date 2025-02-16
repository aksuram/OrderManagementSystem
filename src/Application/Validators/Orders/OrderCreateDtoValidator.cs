using FluentValidation;
using OrderManagementSystem.Application.Models.Orders;

namespace OrderManagementSystem.Application.Validators.Orders
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.Products)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Order can not be empty.");

            RuleFor(x => x.Products.Count)
                .LessThanOrEqualTo(10)
                .WithMessage("Order can not have more than 10 products.");

            RuleForEach(x => x.Products)
                .SetValidator(x => new OrderProductCreateDtoValidator());
        }
    }

    public class OrderProductCreateDtoValidator : AbstractValidator<OrderProductCreateDto>
    {
        public OrderProductCreateDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.Stop)
                .NotEqual(Guid.Empty)
                .WithMessage("Product's id can not be empty.");

            RuleFor(x => x.Quantity)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Product's quantity can not be less than 1.")
                .LessThanOrEqualTo(100)
                .WithMessage("Product's quantity can not exceed 100.");
        }
    }
}

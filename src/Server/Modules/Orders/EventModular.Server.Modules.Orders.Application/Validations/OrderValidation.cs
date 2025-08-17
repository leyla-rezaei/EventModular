using FluentValidation;
using EventModular.Shared.Dtos.Order;

namespace EventModular.Server.Modules.Orders.Application.Validations;

public class OrderValidation : AbstractValidator<OrderRequestDto>
{
    public OrderValidation()
    {
        RuleFor(x => x.BuyerUserId)
            .NotEmpty().WithMessage("buyer user id is required.");

        RuleFor(x => x.CurrencyCode)
            .NotEmpty().WithMessage("currency code is required.");
          
        RuleFor(x => x.Subtotal)
            .GreaterThanOrEqualTo(0).WithMessage("subtotal must be >= 0.");

        RuleFor(x => x.DiscountTotal)
            .GreaterThanOrEqualTo(0).WithMessage("discount total must be >= 0.");

        RuleFor(x => x.TaxTotal)
            .GreaterThanOrEqualTo(0).WithMessage("tax total must be >= 0.");

        RuleFor(x => x.GrandTotal)
            .GreaterThanOrEqualTo(0).WithMessage("grand total must be >= 0.");

        RuleFor(x => x)
          .Must(x => x.GrandTotal == x.Subtotal - x.DiscountTotal + x.TaxTotal)
          .WithMessage("grand total must be equal to subtotal - discountTotal + taxTotal.");

        RuleForEach(x => x.Items)
            .SetValidator(new OrderItemValidation());
    }
}

public class OrderItemValidation : AbstractValidator<OrderItemRequestDto>
{
    public OrderItemValidation()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("product id is required.");

        RuleFor(x => x.ProductKind)
            .NotEmpty().WithMessage("product kind is required.");

        RuleFor(x => x.SnapshotTitle)
            .NotEmpty().WithMessage("snapshot title is required.");

        RuleFor(x => x.CurrencyCode)
            .NotEmpty().WithMessage("currency code is required.");

        RuleFor(x => x.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("unit price must be >= 0.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("quantity must be > 0.");
    }
}

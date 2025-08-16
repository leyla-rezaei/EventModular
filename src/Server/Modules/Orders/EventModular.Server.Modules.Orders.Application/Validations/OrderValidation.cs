using FluentValidation;
using EventModular.Shared.Dtos.Order;

namespace EventModular.Server.Modules.Orders.Application.Validations;
public class OrderValidation : AbstractValidator<OrderRequestDto>
{
    public OrderValidation()
    {
        RuleFor(x => x.BuyerUserId).NotEmpty();
        RuleFor(x => x.CurrencyCode).NotEmpty().Length(3);
        RuleFor(x => x.Items).NotEmpty();

        RuleForEach(x => x.Items).SetValidator(new OrderItemValidation());

        // همه آیتم‌ها باید با ارز هدر یکی باشند
        RuleFor(x => x)
            .Must(o => o.Items.All(i => i.CurrencyCode == o.CurrencyCode))
            .WithMessage("All items must have the same currency as the order.");
    }
}

public class OrderItemValidation : AbstractValidator<OrderItemRequestDto>
{
    public OrderItemValidation()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.SnapshotTitle).NotEmpty().MaximumLength(300);
        RuleFor(x => x.CurrencyCode).NotEmpty().Length(3);
        RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.ProductKind).IsInEnum();
    }
}



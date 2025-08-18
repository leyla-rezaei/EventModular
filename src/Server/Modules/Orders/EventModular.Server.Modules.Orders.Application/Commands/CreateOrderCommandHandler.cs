using EventModular.Server.Modules.Orders.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Order;
using EventModular.Shared.Enums.Order;
using MediatR;

namespace EventModular.Server.Modules.Orders.Application.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // محاسبه جمع‌ها
        var subtotal = request.dto.Items.Sum(i => i.UnitPrice * i.Quantity);
        var discount = 0m; 
        var tax = 0m;     
        var grandTotal = subtotal - discount + tax;

        var order = new Order
        {
            BuyerUserId = request.dto.BuyerUserId,
            RelatedEntityId = request.dto.RelatedEntityId,
            RelatedEntityType = request.dto.RelatedEntityType,
            CurrencyCode = request.dto.CurrencyCode,
            Subtotal = subtotal,
            DiscountTotal = discount,
            TaxTotal = tax,
            GrandTotal = grandTotal,
            Status = OrderStatus.AwaitingPayment,
            Source = request.dto.Source,
            Items = request.dto.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                ProductKind = i.ProductKind,
                SnapshotTitle = i.SnapshotTitle,
                CurrencyCode = i.CurrencyCode,
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity,
                LineTotal = i.UnitPrice * i.Quantity,
                SnapshotJson = i.SnapshotJson
            }).ToList()
        };

        await _context.Set<Order>().AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new OrderResponseDto
        {
            Id = order.Id,
            BuyerUserId = order.BuyerUserId,
            CurrencyCode = order.CurrencyCode,
            Subtotal = order.Subtotal,
            DiscountTotal = order.DiscountTotal,
            TaxTotal = order.TaxTotal,
            GrandTotal = order.GrandTotal,
            Status = order.Status,
            Source = order.Source,
            Items = order.Items.Select(x => new OrderItemResponseDto
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                ProductKind = x.ProductKind,
                SnapshotTitle = x.SnapshotTitle,
                CurrencyCode = x.CurrencyCode,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                LineTotal = x.LineTotal,
                SnapshotJson = x.SnapshotJson
            }).ToList(),
            
        };
    }
}

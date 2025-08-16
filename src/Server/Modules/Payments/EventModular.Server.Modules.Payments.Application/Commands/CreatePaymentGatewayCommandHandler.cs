using EventModular.Server.Modules.Payments.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Payment;
using MediatR;

namespace EventModular.Server.Modules.Payments.Application.Commands;
public class CreatePaymentGatewayCommandHandler : IRequestHandler<CreatePaymentGatewayCommand, PaymentGatewayResponseDto>
{
    private readonly IApplicationDbContext _context;
    public CreatePaymentGatewayCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaymentGatewayResponseDto> Handle(CreatePaymentGatewayCommand request, CancellationToken cancellationToken)
{
    var entity = new PaymentGateway
    {
        Name = request.dto.Name,
        Type = request.dto.Type,
        ApiKey = request.dto.ApiKey,
        ApiSecret = request.dto.ApiSecret,
        EndpointUrl = request.dto.EndpointUrl,
        IsActive = request. dto.IsActive,
        PaymentGatewayCurrencies = request.dto.SupportedCurrencies
            .Select(c => new PaymentGatewayCurrency { CurrencyCode = c.CurrencyCode })
            .ToList()
    };

    await  _context.Set<PaymentGateway>().AddAsync(entity,cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);

    return new PaymentGatewayResponseDto
    {
        Id = entity.Id,
        Name = entity.Name,
        Type = entity.Type,
        ApiKey = entity.ApiKey,
        ApiSecret = entity.ApiSecret,
        EndpointUrl = entity.EndpointUrl,
        IsActive = entity.IsActive,
        PaymentGatewayCurrencies = entity.PaymentGatewayCurrencies
            .Select(c => new PaymentGatewayCurrencyDto { CurrencyCode = c.CurrencyCode })
            .ToList()
    };
}
}

using EventModular.Server.Modules.Tickets.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Tickets;
using MediatR;

namespace EventModular.Server.Modules.Tickets.Application.Commands;
public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, TicketResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateTicketCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<TicketResponseDto> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = new Ticket
        {
            EventId = request.dto.EventId,
            Title = request.dto.Title,
            Capacity = request.dto.Capacity,
            SoldCount = request.dto.SoldCount,
            Localizations = request.dto.Localizations?.Select(x => new TicketLocalization
            {
                Key = x.Key,
                Title = x.Title
            }).ToList() ?? new List<TicketLocalization>(),
            Prices = request.dto.Prices?.Select(p => new TicketPrice
            {
                CurrencyCode = p.CurrencyCode,
                Price = p.Price
            }).ToList() ?? new List<TicketPrice>()
        };

        await _context.Set<Ticket>().AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new TicketResponseDto
        {
            Id = entity.Id,
            EventId = entity.EventId,
            Title = entity.Title,
            Capacity = entity.Capacity,
            SoldCount = entity.SoldCount,
            Localizations = entity.Localizations.Select(loc => new TicketLocalizationDto
            {
                Key = loc.Key,
                Title = loc.Title
            }).ToList(),
            Prices = entity.Prices.Select(p => new TicketPriceDto
            {
                Id = p.Id,
                CurrencyCode = p.CurrencyCode,
                Price = p.Price
            }).ToList()
        };
    }
}


using EventModular.Server.Modules.Events.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Event;
using EventModular.Shared.Enums.Event;
using MediatR;

namespace EventModular.Server.Modules.Events.Application.Commands;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventResponseDto>
{
    private readonly IApplicationDbContext _context;
    public CreateEventCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<EventResponseDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var status = request.dto.StartTime > DateTime.UtcNow ? EventStatus.Draft : EventStatus.Published;

        var entity = new Event
        {
            IsOnline = request.dto.IsOnline,
            StartTime = request.dto.StartTime,
            OrganizerId = request.dto.OrganizerId,
            EndTime = request.dto.EndTime,
            Location = request.dto.Location,
            EventStatus = status,
             PosterMediaId = request.dto.PosterMediaId,
            Localizations = request.dto.Localizations?.Select(x => new EventLocalization
            {
                Key = x.Key,
                Title = x.Title,
                Description = x.Description,
            }).ToList() ?? new List<EventLocalization>()
        };

        await _context.Set<Event>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

       
        if (request.dto.CategoryIds != null && request.dto.CategoryIds.Any())
        {
            foreach (var categoryId in request.dto.CategoryIds)
            {
                var eventCategory = new EventCategory
                {
                    EventId = entity.Id,
                    CategoryId = categoryId
                };
                await _context.Set<EventCategory>().AddAsync(eventCategory, cancellationToken);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        return new EventResponseDto
        {
            Id = entity.Id,
            IsOnline = entity.IsOnline,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            OrganizerId = entity.OrganizerId,
            Location = entity.Location,
            PosterMediaId = entity.PosterMediaId,
            Localizations = entity.Localizations.Select(x => new EventLocalizationDto
            {
                Key = x.Key,
                Title = x.Title,
                Description = x.Description
            }).ToList()
        };
    }
}

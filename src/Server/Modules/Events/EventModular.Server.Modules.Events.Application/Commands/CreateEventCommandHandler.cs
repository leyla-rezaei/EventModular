using EventModular.Server.Modules.Events.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Event;
using MediatR;

namespace EventModular.Server.Modules.Events.Application.Commands;

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventResponseDto>
    {
        private readonly IApplicationDbContext _context;
        public CreateEventCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<EventResponseDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = new Event
            {
                IsOnline = request.dto.IsOnline,
                StartTime = request.dto.StartTime,
                OrganizerId = request.dto.OrganizerId,
                EndTime = request.dto.EndTime,
                Location =request.dto.Location,
                Localizations = request.dto.Localizations.Select(x => new EventLocalization
                {
                    Key = x.Key,
                    Title = x.Title,
                    Description = x.Description,
                }).ToList()
            };

            await _context.Set<Event>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new EventResponseDto
            {
                Id = entity.Id,
                IsOnline = entity.IsOnline,
                StartTime = entity.StartTime,
                OrganizerId = entity.OrganizerId,
                Location = entity.Location,
                Localizations = entity.Localizations.Select(x => new EventLocalizationDto
                {
                    Key = x.Key,
                    Title = x.Title,
                    Description = x.Description
                }).ToList()
            };
        }
    }

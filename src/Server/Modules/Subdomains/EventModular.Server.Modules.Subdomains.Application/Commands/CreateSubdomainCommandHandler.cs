using EventModular.Server.Modules.Subdomains.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Subdomains;
using MediatR;

namespace EventModular.Server.Modules.Subdomains.Application.Commands;
public class CreateSubdomainCommandHandler : IRequestHandler<CreateSubdomainCommand, SubdomainResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateSubdomainCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<SubdomainResponseDto> Handle(CreateSubdomainCommand request, CancellationToken cancellationToken)
    {
        var entity = new Subdomain
        {
            OrganizerId = request.dto.OrganizerId,
            DomainName = request.dto.DomainName,
            Localizations = request.dto.Localizations?.Select(x => new SubdomainLocalization
            {
                Key = x.Key,
                Title = x.Title,
                Description = x.Description
            }).ToList() ?? new List<SubdomainLocalization>()
        };

        await _context.Set<Subdomain>().AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new SubdomainResponseDto
        {
            Id = entity.Id,
            OrganizerId = entity.OrganizerId,
            DomainName = entity.DomainName,
            IsActive = entity.IsActive,
            Localizations = entity.Localizations.Select(x => new SubdomainLocalizationDto
            {
                Key = x.Key,
                Title = x.Title,
                Description = x.Description
            }).ToList()
        };
    }
}

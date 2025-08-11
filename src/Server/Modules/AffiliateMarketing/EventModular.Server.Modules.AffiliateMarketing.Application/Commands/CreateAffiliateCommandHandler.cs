using EventModular.Server.Modules.AffiliateMarketing.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Affiliate;
using MediatR;

namespace EventModular.Server.Modules.AffiliateMarketing.Application.Commands;
public class CreateAffiliateCommandHandler : IRequestHandler<CreateAffiliateCommand, AffiliateResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateAffiliateCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<AffiliateResponseDto> Handle(CreateAffiliateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Affiliate
        {
            OrganizerId = request.dto.OrganizerId,
            Code = request.dto.Code,
            CommissionRate = request.dto.CommissionRate,
            IsActive = request.dto.IsActive,
            Localizations = request.dto.Localizations?.Select(x => new AffiliateLocalization
            {
                Key = x.Key,
                Title = x.Title,
                Description = x.Description
            }).ToList() ?? new List<AffiliateLocalization>()
        };

        await  _context.Set<Affiliate>().AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new AffiliateResponseDto
        {
            Id = entity.Id,
            OrganizerId = entity.OrganizerId,
            Code = entity.Code,
            CommissionRate = entity.CommissionRate,
            IsActive = entity.IsActive,
            Localizations = entity.Localizations.Select(x => new AffiliateLocalizationDto
            {
                Key = x.Key,
                Title = x.Title,
                Description = x.Description
            }).ToList()
        };
    }
}

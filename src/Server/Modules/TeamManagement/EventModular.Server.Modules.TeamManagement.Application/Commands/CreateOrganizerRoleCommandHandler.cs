using EventModular.Server.Modules.TeamManagement.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.TeamManagement;
using MediatR;

namespace EventModular.Server.Modules.TeamManagement.Application.Commands;
public class CreateOrganizerRoleCommandHandler : IRequestHandler<CreateOrganizerRoleCommand, OrganizerRoleResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateOrganizerRoleCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<OrganizerRoleResponseDto> Handle(CreateOrganizerRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = new OrganizerRole
        {
            OrganizerId = request.dto.OrganizerId,
            RoleKey = request.dto.RoleKey,
            Localizations = request.dto.Localizations?.Select(loc => new OrganizerRoleLocalization
            {
                Key = loc.Key,
                Title = loc.Title,
                Description = loc.Description
            }).ToList() ?? new List<OrganizerRoleLocalization>(),
            Permissions = request.dto.Permissions?.Select(p => new OrganizerRolePermission
            {
                PermissionKey = p.PermissionKey
            }).ToList() ?? new List<OrganizerRolePermission>()
        };

        await _context.Set<OrganizerRole>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new OrganizerRoleResponseDto
        {
            Id = entity.Id,
            OrganizerId = entity.OrganizerId,
            RoleKey = entity.RoleKey,
            Localizations = entity.Localizations.Select(x => new OrganizerRoleLocalizationDto
            {
                Key = x.Key,
                Title = x.Title,
                Description = x.Description
            }).ToList(),
            Permissions = entity.Permissions.Select(p => new OrganizerRolePermissionDto
            {
                Id = p.Id,
                PermissionKey = p.PermissionKey
            }).ToList()
        };
    }
}

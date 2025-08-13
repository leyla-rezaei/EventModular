using FluentValidation;
using EventModular.Shared.Dtos.TeamManagement;

namespace EventModular.Server.Modules.TeamManagement.Application.Validations;


public class OrganizerRoleValidation : AbstractValidator<OrganizerRoleRequestDto>
{
    public OrganizerRoleValidation()
    {
        RuleFor(x => x.OrganizerId).NotEmpty();
        RuleFor(x => x.RoleKey).NotEmpty();

        RuleForEach(x => x.Localizations!).SetValidator(new OrganizerRoleLocalizationValidation());
        RuleForEach(x => x.Permissions!).SetValidator(new OrganizerRolePermissionValidation());
    }
}

public class OrganizerRoleLocalizationValidation : AbstractValidator<OrganizerRoleLocalizationDto>
{
    public OrganizerRoleLocalizationValidation()
    {
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}

public class OrganizerRolePermissionValidation : AbstractValidator<OrganizerRolePermissionDto>
{
    public OrganizerRolePermissionValidation()
    {
        RuleFor(x => x.PermissionKey).NotEmpty();
    }
}

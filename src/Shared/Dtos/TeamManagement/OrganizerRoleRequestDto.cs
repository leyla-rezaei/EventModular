using EventModular.Shared.Enums.TeamManagement;

namespace EventModular.Shared.Dtos.TeamManagement;
public class OrganizerRoleRequestDto
{
    public Guid OrganizerId { get; set; }
    public string RoleKey { get; set; } = string.Empty;
    public bool IsFixedRole => Enum.TryParse<FixedRoles>(RoleKey, ignoreCase: true, out _);

    public List<OrganizerRoleLocalizationDto>? Localizations { get; set; }
    public List<OrganizerRolePermissionDto>? Permissions { get; set; }
}

public class OrganizerRolePermissionDto
{
    public Guid Id { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
}

public class OrganizerRoleLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

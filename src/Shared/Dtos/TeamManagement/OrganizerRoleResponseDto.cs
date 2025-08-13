namespace EventModular.Shared.Dtos.TeamManagement;
public class OrganizerRoleResponseDto
{
    public Guid Id { get; set; }
    public Guid OrganizerId { get; set; }
    public string RoleKey { get; set; } = string.Empty;
    public List<OrganizerRoleLocalizationDto>? Localizations { get; set; }
    public List<OrganizerRolePermissionDto>? Permissions { get; set; }
}

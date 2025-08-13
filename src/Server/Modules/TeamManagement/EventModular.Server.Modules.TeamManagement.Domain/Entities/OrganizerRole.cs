using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.TeamManagement;

namespace EventModular.Server.Modules.TeamManagement.Domain.Entities;
[Table(nameof(OrganizerRole), Schema = SchemaConsts.TeamManagement)]
public class OrganizerRole : BaseEntity
{
    public Guid OrganizerId { get; set; }
    public string RoleKey { get; set; } = string.Empty; //  Admin, Moderator, Support,...
    public bool IsFixedRole => Enum.TryParse<FixedRoles>(RoleKey, ignoreCase: true, out _);

    public ICollection<OrganizerRoleLocalization> Localizations { get; set; } = new List<OrganizerRoleLocalization>();
    public ICollection<OrganizerRolePermission> Permissions { get; set; } = new List<OrganizerRolePermission>();
}

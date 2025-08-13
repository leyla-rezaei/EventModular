using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.TeamManagement.Domain.Entities;
[Table(nameof(OrganizerRolePermission), Schema = SchemaConsts.TeamManagement)]
public class OrganizerRolePermission : BaseEntity
{
    public Guid OrganizerRoleId { get; set; }
    public OrganizerRole OrganizerRole { get; set; }

    public string PermissionKey { get; set; } = string.Empty; //  "Event.Create", "Course.Manage"...
}

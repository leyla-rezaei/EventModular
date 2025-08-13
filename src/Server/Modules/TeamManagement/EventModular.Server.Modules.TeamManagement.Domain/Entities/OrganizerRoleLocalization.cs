using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.TeamManagement.Domain.Entities;
[Table(nameof(OrganizerRoleLocalization), Schema = SchemaConsts.Localization)]
public class OrganizerRoleLocalization : BaseLocalization
{
    public Guid OrganizerRoleId { get; set; }
    public OrganizerRole OrganizerRole { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

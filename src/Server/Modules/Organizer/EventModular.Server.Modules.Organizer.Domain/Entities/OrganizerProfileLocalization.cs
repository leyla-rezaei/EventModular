using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Organizer.Domain.Entities;
[Table(nameof(OrganizerProfileLocalization), Schema = SchemaConsts.Localization)]

public class OrganizerProfileLocalization : BaseLocalization
{
    public string Bio { get; set; } = string.Empty;
    public string? ProfileName { get; set; }

    public Guid OrganizerId { get; set; } 
    public OrganizerProfile Organizer { get; set; }
}

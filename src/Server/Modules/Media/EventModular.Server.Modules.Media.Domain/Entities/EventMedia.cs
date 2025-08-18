using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Media;

namespace EventModular.Server.Modules.Media.Domain.Entities;
[Table(nameof(EventMedia), Schema = nameof(SchemaConsts.Media))]
public class EventMedia : MediaFile
{
    public EventMedia()
    {
        MediaContentType = MediaContentType.Event;
    }

    public Guid EventId { get; set; }
    public bool IsCover { get; set; } 

    public ICollection<EventMediaLocalization> Localizations { get; set; } = new List<EventMediaLocalization>();
}

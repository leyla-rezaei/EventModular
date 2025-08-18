using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Media;

namespace EventModular.Server.Modules.Media.Domain.Entities;
[Table(nameof(MediaUsage), Schema = SchemaConsts.Media)]
public class MediaUsage : BaseEntity
{
    public Guid MediaFileId { get; set; }
    public MediaFile MediaFile { get; set; }

    public MediaOwnerType OwnerType { get; set; }   
    public Guid OwnerTypeId { get; set; }
    public MediaUsageType UsageType { get; set; }  
}

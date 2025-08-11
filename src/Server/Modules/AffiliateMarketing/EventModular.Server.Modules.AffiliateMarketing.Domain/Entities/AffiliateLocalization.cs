using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.AffiliateMarketing.Domain.Entities;
[Table(nameof(AffiliateLocalization), Schema = SchemaConsts.Localization)]
public class AffiliateLocalization : BaseLocalization
{
    public Guid AffiliateId { get; set; }
    public Affiliate Affiliate { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

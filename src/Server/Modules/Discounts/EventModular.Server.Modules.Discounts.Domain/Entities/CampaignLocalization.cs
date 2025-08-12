using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Discounts.Domain.Entities;
[Table(nameof(CampaignLocalization), Schema = SchemaConsts.Localization)]
public class CampaignLocalization : BaseLocalization
{
    public Guid CampaignId { get; set; }
    public Campaign Campaign { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

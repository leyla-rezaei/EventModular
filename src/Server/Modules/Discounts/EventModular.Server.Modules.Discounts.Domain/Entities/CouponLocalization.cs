using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Discounts.Domain.Entities;
[Table(nameof(CouponLocalization), Schema = SchemaConsts.Localization)]
public class CouponLocalization : BaseLocalization
{
    public Guid CouponId { get; set; }
    public Coupon Coupon { get; set; }
    public string Description { get; set; } = string.Empty;
}

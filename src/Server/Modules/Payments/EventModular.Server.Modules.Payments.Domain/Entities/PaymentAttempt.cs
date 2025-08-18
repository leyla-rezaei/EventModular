using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Payment;

namespace EventModular.Server.Modules.Payments.Domain.Entities;
[Table(nameof(PaymentAttempt), Schema = SchemaConsts.Payment)]
public class PaymentAttempt : BaseEntity
{
    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; }

    public DateTime AttemptedOn { get; set; }
    public PaymentStatus Status { get; set; }
    public string? ResponseJson { get; set; }
}

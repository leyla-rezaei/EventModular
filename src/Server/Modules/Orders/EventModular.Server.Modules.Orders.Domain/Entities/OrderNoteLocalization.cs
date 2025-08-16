using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Orders.Domain.Entities;
[Table(nameof(OrderNoteLocalization), Schema = SchemaConsts.Localization)]
public class OrderNoteLocalization : BaseLocalization
{
    public Guid OrderNoteId { get; set; }
    public OrderNote OrderNote { get; set; }

    public string Text { get; set; } = string.Empty;
}

namespace EventModular.Shared.Entities;
public interface IBaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset? ModificationDate { get; set; }
    public bool IsArchived { get; set; }
}

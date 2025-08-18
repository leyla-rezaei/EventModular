using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Tag;

namespace EventModular.Server.Modules.Tags.Domain.Entities;
[Table(nameof(Tag), Schema = nameof(SchemaConsts.Tag))]
public class Tag : BaseEntity
{
    public bool IsApproved { get; set; }
    public TagType TagType { get; set; }

    #region Navigation Properties
    public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    public ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();
    public ICollection<EventTag> EventTags { get; set; } = new List<EventTag>();
    public ICollection<TagLocalization> Localizations { get; set; } = new List<TagLocalization>();
    #endregion
}

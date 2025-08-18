using EventModular.Shared.Enums.Tag;

namespace EventModular.Shared.Dtos.Tag;

public class TagRequestDto
{
    public bool IsApproved { get; set; }
    public TagType TagType { get; set; }
    public List<TagLocalizationDto> Localizations { get; set; } = new();
}

public class TagLocalizationDto
{ 
    public string key { get; set; } = string.Empty;
    public string TagName { get; set; } = string.Empty;
}

public class PostTagRequestDto
{
    public Guid PostId { get; set; }
    public Guid TagId { get; set; }
}


public class CourseTagRequestDto
{
    public Guid CourseId { get; set; }
    public Guid TagId { get; set; }
}

public class EventTagRequestDto
{
    public Guid EventId { get; set; }
    public Guid TagId { get; set; }
}


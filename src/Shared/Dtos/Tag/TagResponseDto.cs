using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventModular.Shared.Enums.Tag;

namespace EventModular.Shared.Dtos.Tag;
public class TagResponseDto
{
    public Guid Id { get; set; }
    public bool IsApproved { get; set; }
    public TagType TagType { get; set; }
    public List<TagLocalizationDto> Localizations { get; set; } = new();
}

public class PostTagResponseDto
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid TagId { get; set; }
}

public class CourseTagResponseDto
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid TagId { get; set; }
}

public class EventTagResponseDto
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid TagId { get; set; }
}

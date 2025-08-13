using EventModular.Server.Modules.Courses.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Course;
using MediatR;

namespace EventModular.Server.Modules.Courses.Application.Commands;
public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateCourseCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<CourseResponseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var entity = new Course
        {
            OrganizerId = request.dto.OrganizerId,
            Price = request.dto.Price,
            IsPublished = request.dto.IsPublished,
            PublishDate = request.dto.PublishDate,
            ThumbnailUrl = request.dto.ThumbnailUrl,
            Localizations = request.dto.Localizations?.Select(x => new CourseLocalization
            {
                Key = x.Key,
                Title = x.Title,
                Summary = x.Summary,
                Description = x.Description
            }).ToList() ?? new List<CourseLocalization>(),
            Sections = request.dto.Sections?.Select(sec => new CourseSection
            {
                Index = sec.Index,
                Localizations = sec.Localizations?.Select(x => new CourseSectionLocalization
                {
                    Key = x.Key,
                    Title = x.Title,
                    Summary = x.Summary
                }).ToList() ?? new List<CourseSectionLocalization>(),
                Lessons = sec.Lessons?.Select(lesson => new CourseLesson
                {
                    Index = lesson.Index,
                    Duration = lesson.Duration,
                    Localizations = lesson.Localizations?.Select(x => new CourseLessonLocalization
                    {
                        Key = x.Key,
                        Title = x.Title,
                        Summary = x.Summary
                    }).ToList() ?? new List<CourseLessonLocalization>()
                }).ToList() ?? new List<CourseLesson>()
            }).ToList() ?? new List<CourseSection>()
        };

        await _context.Set<Course>().AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        // Map back to Response DTO
        return new CourseResponseDto
        {
            Id = entity.Id,
            OrganizerId = entity.OrganizerId,
            Price = entity.Price,
            IsPublished = entity.IsPublished,
            PublishDate = entity.PublishDate,
            ThumbnailUrl = entity.ThumbnailUrl,
            Localizations = entity.Localizations.Select(x => new CourseLocalizationDto
            {
                Key = x.Key,
                Title = x.Title,
                Summary = x.Summary,
                Description = x.Description
            }).ToList(),
            Sections = entity.Sections.Select(sec => new CourseSectionResponseDto
            {
                Id = sec.Id,
                Index = sec.Index,
                Localizations = sec.Localizations.Select(x => new CourseSectionLocalizationDto
                {
                    Key = x.Key,
                    Title = x.Title,
                    Summary = x.Summary
                }).ToList(),

                Lessons = sec.Lessons.Select(lesson => new CourseLessonResponseDto
                {
                    Id = lesson.Id,
                    Index = lesson.Index,
                    Duration = lesson.Duration,
                    Localizations = lesson.Localizations.Select(x => new CourseLessonLocalizationDto
                    {
                        Key = x.Key,
                        Title = x.Title,
                        Summary = x.Summary
                    }).ToList()
                }).ToList()
            }).ToList()
        };
    }
}

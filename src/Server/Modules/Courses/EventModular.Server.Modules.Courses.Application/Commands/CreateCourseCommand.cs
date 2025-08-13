using EventModular.Shared.Dtos.Course;
using MediatR;

namespace EventModular.Server.Modules.Courses.Application.Commands;
public record CreateCourseCommand(CourseRequestDto dto) : IRequest<CourseResponseDto>;

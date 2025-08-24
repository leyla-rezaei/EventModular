using MediatR;
namespace EventModular.Shared.Contracts.Organizer;
public record GetDefaultOrganizerQuery : IRequest<Guid>;

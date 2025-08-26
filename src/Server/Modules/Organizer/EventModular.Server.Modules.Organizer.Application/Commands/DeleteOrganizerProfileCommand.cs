using EventModular.Shared.Constants.Response;
using MediatR;

namespace EventModular.Server.Modules.Organizer.Application.Commands;
public record DeleteOrganizerProfileCommand(Guid Id)
    : IRequest<JustResponse>;

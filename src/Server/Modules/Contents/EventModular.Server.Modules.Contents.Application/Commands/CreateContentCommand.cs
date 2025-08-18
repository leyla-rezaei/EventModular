using MediatR;
using EventModular.Shared.Dtos.Content;

namespace EventModular.Server.Modules.Contents.Application.Commands;

public record CreateContentCommand(ContentRequestDto Request) : IRequest<Guid>;

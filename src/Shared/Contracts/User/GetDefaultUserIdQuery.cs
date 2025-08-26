using MediatR;

namespace EventModular.Shared.Contracts.User;
public sealed record GetDefaultUserIdQuery : IRequest<Guid>;

using EventModular.Shared.Dtos.Subdomains;
using MediatR;

namespace EventModular.Server.Modules.Subdomains.Application.Commands;
public record CreateSubdomainCommand(SubdomainRequestDto dto) : IRequest<SubdomainResponseDto>;

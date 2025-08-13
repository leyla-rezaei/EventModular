using EventModular.Shared.Dtos.TeamManagement;
using MediatR;

namespace EventModular.Server.Modules.TeamManagement.Application.Commands;

public record CreateOrganizerRoleCommand(OrganizerRoleRequestDto dto) : IRequest<OrganizerRoleResponseDto>;


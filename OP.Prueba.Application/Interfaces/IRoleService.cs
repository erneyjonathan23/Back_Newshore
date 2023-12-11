using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.Features.CreateRoleCommand.Commands.CreateRoleCommand;
using OP.Prueba.Application.Features.DeleteRoleCommand.Commands.DeleteRoleCommand;
using OP.Prueba.Application.Features.GetRoleByIdQuery.Queries.GetRoleByIdQuery;
using OP.Prueba.Application.Features.Role.Queries.GetAllRolesQuery;
using OP.Prueba.Application.Features.UpdateRoleCommand.Commands.UpdateRoleCommand;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Interfaces
{
    public interface IRoleService
    {
        Task<PagedResponse<List<RolesDto>>> GetAllRoles(GetAllRolesQuery request, CancellationToken cancellationToken);
        Task<Response<RolesDto>> GetRoleById(GetRoleByIdQuery request, CancellationToken cancellationToken);
        Task<Response<int>> DeleteRole(DeleteRoleCommand request, CancellationToken cancellationToken);
        Task<Response<int>> UpdateRole(UpdateRoleCommand request, CancellationToken cancellationToken);
        Task<Response<int>> CreateRole(CreateRoleCommand request, CancellationToken cancellationToken);
    }
}
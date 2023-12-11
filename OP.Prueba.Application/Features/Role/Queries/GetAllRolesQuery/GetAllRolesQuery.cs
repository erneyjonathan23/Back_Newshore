using MediatR;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.Role.Queries.GetAllRolesQuery
{
    public class GetAllRolesQuery : IRequest<PagedResponse<List<RolesDto>>>
    {
        public int? Id { get; set; } = null;
        public string? Role { get; set; } = null;
        public int? Nivel { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, PagedResponse<List<RolesDto>>>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesQueryHandler(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        public async Task<PagedResponse<List<RolesDto>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _roleService.GetAllRoles(request, cancellationToken);
        }
    }
}

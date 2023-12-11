using AutoMapper;
using MediatR;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.GetRoleByIdQuery.Queries.GetRoleByIdQuery
{
    public class GetRoleByIdQuery : IRequest<Response<RolesDto>>
    {
        public int Id { get; set; }
        public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Response<RolesDto>>
        {
            private readonly IRoleService _RoleService;

            public GetRoleByIdQueryHandler(IRoleService RoleService)
            {
                _RoleService = RoleService;
            }

            public async Task<Response<RolesDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
            {
                return await _RoleService.GetRoleById(request, cancellationToken);
            }
        }
    }
}

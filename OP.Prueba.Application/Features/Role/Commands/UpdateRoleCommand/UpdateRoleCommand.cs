using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.UpdateRoleCommand.Commands.UpdateRoleCommand
{
    public class UpdateRoleCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; } = null;
        public string? Role { get; set; } = null;
        public int? Nivel { get; set; } = null;
    }
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Response<int>>
    {
        private readonly IRoleService _RoleService;

        public UpdateRoleCommandHandler(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        public async Task<Response<int>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _RoleService.UpdateRole(request, cancellationToken);
        }
    }
}

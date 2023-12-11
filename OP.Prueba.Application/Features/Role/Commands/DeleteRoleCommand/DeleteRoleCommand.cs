using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.DeleteRoleCommand.Commands.DeleteRoleCommand
{
    public class DeleteRoleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Response<int>>
    {
        private readonly IRoleService _RoleService;

        public DeleteRoleCommandHandler(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        public async Task<Response<int>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _RoleService.DeleteRole(request, cancellationToken);
        }
    }
}

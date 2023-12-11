using AutoMapper;
using MediatR;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Services;
using OP.Prueba.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.CreateRoleCommand.Commands.CreateRoleCommand
{
    public class CreateRoleCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; } = null;
        public string? Role { get; set; } = null;
        public int? Nivel { get; set; } = null;
    }
    public class CreateDataMasterCommandHandler : IRequestHandler<CreateRoleCommand, Response<int>>
    {
        private readonly IRoleService _RoleService;

        public CreateDataMasterCommandHandler(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        public async Task<Response<int>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _RoleService.CreateRole(request, cancellationToken);
        }
    }
}
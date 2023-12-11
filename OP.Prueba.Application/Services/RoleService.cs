using AutoMapper;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Features.CreateRoleCommand.Commands.CreateRoleCommand;
using OP.Prueba.Application.Features.DeleteRoleCommand.Commands.DeleteRoleCommand;
using OP.Prueba.Application.Features.GetRoleByIdQuery.Queries.GetRoleByIdQuery;
using OP.Prueba.Application.Features.Role.Queries.GetAllRolesQuery;
using OP.Prueba.Application.Features.UpdateRoleCommand.Commands.UpdateRoleCommand;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Specifications;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;
using NPOI.POIFS.Crypt.Dsig;

namespace OP.Prueba.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepositoryAsync<Domain.Entities.Roles> _repositoryAsync;
        private readonly IMapper _mapper;
        public RoleService(IRepositoryAsync<Roles> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<PagedResponse<List<RolesDto>>> GetAllRoles(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _repositoryAsync.ListAsync(new PagedRoleSpecification(request.PageSize, request.PageNumber, request.Id, request.Role, request.Nivel));
            var rolesCount = await _repositoryAsync.CountAsync(new PagedRoleSpecification(null, null, request.Id, request.Role, request.Nivel));
            var rolesDto = new List<RolesDto>();
            if (roles.Count > 0)
            {
                rolesDto = (from data in roles
                            select new RolesDto
                            {
                                Id = data.Id,
                                Role = data.Role,
                                Nivel = data.Nivel,
                                Usuarios = data.Usuarios,
                                FeBaja = data.FeBaja,
                                FeRegistro = data.FeRegistro
                            }).ToList();
            }
            return new PagedResponse<List<RolesDto>>(rolesDto, request.PageNumber, request.PageSize, rolesCount);
        }

        public async Task<Response<int>> CreateRole(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var newRegister = new Roles()
            {
                Id = 0,
                Nivel = (int)request.Nivel,
                Role = (string)request.Role,
            };
            var data = await _repositoryAsync.AddAsync(newRegister);
            var response = new Response<int>()
            {
                Message = "El registro se ha realizado exitosamente!",
                Data = data.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<RolesDto>> GetRoleById(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var maestra = await _repositoryAsync.GetByIdAsync(request.Id);
            var dto = new RolesDto();
            if (maestra != null)
            {
                dto = new RolesDto()
                {
                    Id = maestra.Id,
                    Role = maestra.Role,
                    Nivel = maestra.Nivel,
                    FeBaja = maestra.FeBaja,
                    FeRegistro = maestra.FeRegistro,
                };
            }
            var response = new Response<RolesDto>()
            {
                Message = "El registro se ha encontrado exitosamente!",
                Data = dto,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> DeleteRole(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var Roleo = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Roleo == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            await _repositoryAsync.DeleteAsync(Roleo);
            var response = new Response<int>()
            {
                Message = "El registro se ha eliminado exitosamente!",
                Data = Roleo.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> UpdateRole(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var Roleo = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Roleo == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            Roleo.Role = (string)request.Role;
            Roleo.Nivel = request.Nivel;
            await _repositoryAsync.UpdateAsync(Roleo);
            var response = new Response<int>()
            {
                Message = "El registro se ha actualizado exitosamente!",
                Data = Roleo.Id,
                Succeeded = true
            };
            return response;
        }
    }
}
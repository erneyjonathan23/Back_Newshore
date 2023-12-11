using AutoMapper;
using OP.Prueba.Application.DTOs.EmergencyContacts;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Features.EmergencyContact.Queries.GetAllEmergencyContactsQuery;
using OP.Prueba.Application.Features.DeleteEmergencyContactCommand.Commands.DeleteEmergencyContactCommand;
using OP.Prueba.Application.Features.CreateEmergencyContactCommand.Commands.CreateEmergencyContactCommand;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Specifications;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;
using OP.Prueba.Application.Features.UpdateEmergencyContactCommand.Commands.UpdateEmergencyContactCommand;
using OP.Prueba.Application.Features.GetEmergencyContactByIdQuery.Queries.GetEmergencyContactByIdQuery;
using NPOI.POIFS.Crypt.Dsig;

namespace OP.Prueba.Application.Services
{
    public class EmergencyContactService : IEmergencyContactService
    {
        private readonly IRepositoryAsync<Domain.Entities.ContactoEmergencia> _repositoryAsync;
        private readonly IMapper _mapper;

        public EmergencyContactService(IRepositoryAsync<ContactoEmergencia> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PagedResponse<List<EmergencyContactsDto>>> GetAllEmergencyContacts(GetAllEmergencyContactsQuery request, CancellationToken cancellationToken)
        {
            var EmergencyContacts = await _repositoryAsync.ListAsync(new PagedEmergencyContactSpecification(request.PageSize, request.PageNumber, request.Id, request.Nombres, request.Apellidos, request.NumeroContacto, request.Email));
            var EmergencyContactsCount = await _repositoryAsync.CountAsync(new PagedEmergencyContactSpecification(null, null, request.Id, request.Nombres, request.Apellidos, request.NumeroContacto, request.Email));
            var EmergencyContactsDto = new List<EmergencyContactsDto>();
            if (EmergencyContacts.Count > 0)
            {
                EmergencyContactsDto = (from data in EmergencyContacts
                            select new EmergencyContactsDto
                            {
                                Id = data.Id,
                                Nombres = data.Nombres,
                                Apellidos = data.Apellidos,
                                NumeroContacto = data.NumeroContacto,
                                Email = data.Email,
                                FeBaja = data.FeBaja,
                                FeRegistro = data.FeRegistro
                            }).ToList();
            }
            return new PagedResponse<List<EmergencyContactsDto>>(EmergencyContactsDto, request.PageNumber, request.PageSize, EmergencyContactsCount);
        }

        public async Task<Response<int>> CreateEmergencyContact(CreateEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            var newRegister = new ContactoEmergencia()
            {
                Id = 0,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                NumeroContacto = (long)request.NumeroContacto,
                Email = request.Email,
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

        public async Task<Response<EmergencyContactsDto>> GetEmergencyContactById(GetEmergencyContactByIdQuery request, CancellationToken cancellationToken)
        {
            var maestra = await _repositoryAsync.GetByIdAsync(request.Id);
            var dto = new EmergencyContactsDto();
            if (maestra != null)
            {
                dto = new EmergencyContactsDto()
                {
                    Id = maestra.Id,
                    Nombres = maestra.Nombres,
                    Apellidos = maestra.Apellidos,
                    NumeroContacto = maestra.NumeroContacto,
                    Email = maestra.Email,
                    FeBaja = maestra.FeBaja,
                    FeRegistro = maestra.FeRegistro
                };
            }
            var response = new Response<EmergencyContactsDto>()
            {
                Message = "El registro se ha encontrado exitosamente!",
                Data = dto,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> DeleteEmergencyContact(DeleteEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            var EmergencyContacto = await _repositoryAsync.GetByIdAsync(request.Id);
            if (EmergencyContacto == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            await _repositoryAsync.DeleteAsync(EmergencyContacto);
            var response = new Response<int>()
            {
                Message = "El registro se ha eliminado exitosamente!",
                Data = EmergencyContacto.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> UpdateEmergencyContact(UpdateEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            var EmergencyContacto = await _repositoryAsync.GetByIdAsync(request.Id);
            if (EmergencyContacto == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            EmergencyContacto.Nombres = (string)request.Nombres;
            EmergencyContacto.Apellidos = (string)request.Apellidos;
            EmergencyContacto.NumeroContacto = (long)request.NumeroContacto;
            EmergencyContacto.Email = (string)request.Email;
            await _repositoryAsync.UpdateAsync(EmergencyContacto);
            var response = new Response<int>()
            {
                Message = "El registro se ha actualizado exitosamente!",
                Data = EmergencyContacto.Id,
                Succeeded = true
            };
            return response;
        }
    }
}
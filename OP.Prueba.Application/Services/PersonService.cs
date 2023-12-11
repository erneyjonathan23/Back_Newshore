using AutoMapper;
using OP.Prueba.Application.DTOs.Persons;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Features.Person.Queries.GetAllPersonsQuery;
using OP.Prueba.Application.Features.DeletePersonCommand.Commands.DeletePersonCommand;
using OP.Prueba.Application.Features.CreatePersonCommand.Commands.CreatePersonCommand;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Specifications;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;
using OP.Prueba.Application.Features.UpdatePersonCommand.Commands.UpdatePersonCommand;
using OP.Prueba.Application.Features.GetPersonByIdQuery.Queries.GetPersonByIdQuery;
using NPOI.POIFS.Crypt.Dsig;

namespace OP.Prueba.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryAsync<Domain.Entities.Personas> _repositoryAsync;
        private readonly IMapper _mapper;

        public PersonService(IRepositoryAsync<Personas> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PagedResponse<List<PersonsDto>>> GetAllPersons(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var Persons = await _repositoryAsync.ListAsync(new PagedPersonSpecification(request.PageSize, request.PageNumber, request.Id, request.Usuario, request.Nombres,
                request.Apellidos, request.Genero, request.TipoDocumento, request.NumeroDocumento, request.Email, request.TelefonoContacto));
            var PersonsCount = await _repositoryAsync.CountAsync(new PagedPersonSpecification(null, null, request.Id, request.Usuario, request.Nombres,
                request.Apellidos, request.Genero, request.TipoDocumento, request.NumeroDocumento, request.Email, request.TelefonoContacto));
            var PersonsDto = new List<PersonsDto>();

            if (Persons.Count > 0)
            {
                PersonsDto = (from data in Persons
                              select new PersonsDto
                              {
                                  Id = data.Id,
                                  Usuario = (int)data.Usuario,
                                  Nombres = data.Nombres,
                                  Apellidos = data.Apellidos,
                                  Genero = data.Genero,
                                  NumeroDocumento = data.NumeroDocumento,
                                  Email = data.Email,
                                  TelefonoContacto = data.TelefonoContacto,
                                  FeBaja = data.FeBaja,
                                  FeRegistro = data.FeRegistro
                              }).ToList();
            }
            return new PagedResponse<List<PersonsDto>>(PersonsDto, request.PageNumber, request.PageSize, PersonsCount);
        }

        public async Task<Response<int>> CreatePerson(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var newRegister = new Personas()
            {
                Id = 0,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                FechaNacimiento = (DateTime)request.FechaNacimiento,
                Genero = (int)request.Genero,
                TipoDocumento = (int)request.TipoDocumento,
                NumeroDocumento = request.NumeroDocumento,
                Email = request.Email,
                TelefonoContacto = (long)request.TelefonoContacto,
                //Usuario = request.Usuario,
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

        public async Task<Response<PersonsDto>> GetPersonById(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var maestra = await _repositoryAsync.GetByIdAsync(request.Id);
            var dto = new PersonsDto();
            if (maestra != null)
            {
                dto = new PersonsDto
                {
                    Id = maestra.Id,
                    Usuario = (int)maestra.Usuario,
                    Nombres = maestra.Nombres,
                    Apellidos = maestra.Apellidos,
                    Genero = maestra.Genero,
                    NumeroDocumento = maestra.NumeroDocumento,
                    Email = maestra.Email,
                    TelefonoContacto = maestra.TelefonoContacto,
                    FeBaja = maestra.FeBaja,
                    FeRegistro = maestra.FeRegistro
                };
            }
            var response = new Response<PersonsDto>()
            {
                Message = "El registro se ha encontrado exitosamente!",
                Data = dto,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> DeletePerson(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var Persono = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Persono == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            await _repositoryAsync.DeleteAsync(Persono);
            var response = new Response<int>()
            {
                Message = "El registro se ha eliminado exitosamente!",
                Data = Persono.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> UpdatePerson(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var Persono = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Persono == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            Persono.Nombres = (string)request.Nombres;
            Persono.Apellidos = request.Apellidos;
            Persono.Genero = (int)request.Genero;
            Persono.TipoDocumento = (int)request.TipoDocumento;
            Persono.NumeroDocumento = (string)request.NumeroDocumento;
            Persono.Email = request.Email;
            Persono.TelefonoContacto = (long)request.TelefonoContacto;
            await _repositoryAsync.UpdateAsync(Persono);
            var response = new Response<int>()
            {
                Message = "El registro se ha actualizado exitosamente!",
                Data = Persono.Id,
                Succeeded = true
            };
            return response;
        }
    }
}
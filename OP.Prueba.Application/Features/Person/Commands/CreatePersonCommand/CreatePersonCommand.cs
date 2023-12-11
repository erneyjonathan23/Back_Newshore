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

namespace OP.Prueba.Application.Features.CreatePersonCommand.Commands.CreatePersonCommand
{
    public class CreatePersonCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; } = null;
        public string? Nombres { get; set; } = null;
        public string? Apellidos { get; set; } = null;
        public DateTime? FechaNacimiento { get; set; } = null;
        public int? Genero { get; set; } = null;
        public int? TipoDocumento { get; set; } = null;
        public string? NumeroDocumento { get; set; } = null;
        public string? Email { get; set; } = null;
        public long? TelefonoContacto { get; set; } = null;
        public int? Usuario { get; set; } = null;
    }
    public class CreateDataMasterCommandHandler : IRequestHandler<CreatePersonCommand, Response<int>>
    {
        private readonly IPersonService _PersonService;

        public CreateDataMasterCommandHandler(IPersonService PersonService)
        {
            _PersonService = PersonService;
        }

        public async Task<Response<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            return await _PersonService.CreatePerson(request, cancellationToken);
        }
    }
}
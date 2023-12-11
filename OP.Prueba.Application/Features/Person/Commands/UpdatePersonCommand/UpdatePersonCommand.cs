using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.UpdatePersonCommand.Commands.UpdatePersonCommand
{
    public class UpdatePersonCommand : IRequest<Response<int>>
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
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Response<int>>
    {
        private readonly IPersonService _PersonService;

        public UpdatePersonCommandHandler(IPersonService PersonService)
        {
            _PersonService = PersonService;
        }

        public async Task<Response<int>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            return await _PersonService.UpdatePerson(request, cancellationToken);
        }
    }
}

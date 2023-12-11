using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.UpdateEmergencyContactCommand.Commands.UpdateEmergencyContactCommand
{
    public class UpdateEmergencyContactCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public long? NumeroContacto { get; set; }
        public string? Email { get; set; } = null;
    }
    public class UpdateEmergencyContactCommandHandler : IRequestHandler<UpdateEmergencyContactCommand, Response<int>>
    {
        private readonly IEmergencyContactService _EmergencyContactService;

        public UpdateEmergencyContactCommandHandler(IEmergencyContactService EmergencyContactService)
        {
            _EmergencyContactService = EmergencyContactService;
        }

        public async Task<Response<int>> Handle(UpdateEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            return await _EmergencyContactService.UpdateEmergencyContact(request, cancellationToken);
        }
    }
}

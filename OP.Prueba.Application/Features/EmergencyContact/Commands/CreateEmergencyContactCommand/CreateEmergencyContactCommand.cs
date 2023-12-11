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

namespace OP.Prueba.Application.Features.CreateEmergencyContactCommand.Commands.CreateEmergencyContactCommand
{
    public class CreateEmergencyContactCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public long? NumeroContacto { get; set; }
        public string? Email { get; set; } = null;
    }
    public class CreateDataMasterCommandHandler : IRequestHandler<CreateEmergencyContactCommand, Response<int>>
    {
        private readonly IEmergencyContactService _EmergencyContactService;

        public CreateDataMasterCommandHandler(IEmergencyContactService EmergencyContactService)
        {
            _EmergencyContactService = EmergencyContactService;
        }

        public async Task<Response<int>> Handle(CreateEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            return await _EmergencyContactService.CreateEmergencyContact(request, cancellationToken);
        }
    }
}
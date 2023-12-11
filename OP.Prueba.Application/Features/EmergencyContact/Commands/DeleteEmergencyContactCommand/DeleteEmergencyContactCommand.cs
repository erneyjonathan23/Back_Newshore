using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.DeleteEmergencyContactCommand.Commands.DeleteEmergencyContactCommand
{
    public class DeleteEmergencyContactCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteEmergencyContactCommandHandler : IRequestHandler<DeleteEmergencyContactCommand, Response<int>>
    {
        private readonly IEmergencyContactService _EmergencyContactService;

        public DeleteEmergencyContactCommandHandler(IEmergencyContactService EmergencyContactService)
        {
            _EmergencyContactService = EmergencyContactService;
        }

        public async Task<Response<int>> Handle(DeleteEmergencyContactCommand request, CancellationToken cancellationToken)
        {
            return await _EmergencyContactService.DeleteEmergencyContact(request, cancellationToken);
        }
    }
}

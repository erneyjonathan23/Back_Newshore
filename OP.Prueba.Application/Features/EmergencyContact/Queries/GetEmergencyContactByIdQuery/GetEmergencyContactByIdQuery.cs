using AutoMapper;
using MediatR;
using OP.Prueba.Application.DTOs.EmergencyContacts;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.GetEmergencyContactByIdQuery.Queries.GetEmergencyContactByIdQuery
{
    public class GetEmergencyContactByIdQuery : IRequest<Response<EmergencyContactsDto>>
    {
        public int Id { get; set; }
        public class GetEmergencyContactByIdQueryHandler : IRequestHandler<GetEmergencyContactByIdQuery, Response<EmergencyContactsDto>>
        {
            private readonly IEmergencyContactService _EmergencyContactService;

            public GetEmergencyContactByIdQueryHandler(IEmergencyContactService EmergencyContactService)
            {
                _EmergencyContactService = EmergencyContactService;
            }

            public async Task<Response<EmergencyContactsDto>> Handle(GetEmergencyContactByIdQuery request, CancellationToken cancellationToken)
            {
                return await _EmergencyContactService.GetEmergencyContactById(request, cancellationToken);
            }
        }
    }
}

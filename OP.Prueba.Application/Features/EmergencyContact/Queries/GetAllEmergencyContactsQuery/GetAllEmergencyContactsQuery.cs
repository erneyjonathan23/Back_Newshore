using MediatR;
using OP.Prueba.Application.DTOs.EmergencyContacts;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.EmergencyContact.Queries.GetAllEmergencyContactsQuery
{
    public class GetAllEmergencyContactsQuery : IRequest<PagedResponse<List<EmergencyContactsDto>>>
    {
        public int? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public long? NumeroContacto { get; set; }
        public string? Email { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllEmergencyContactsQueryHandler : IRequestHandler<GetAllEmergencyContactsQuery, PagedResponse<List<EmergencyContactsDto>>>
    {
        private readonly IEmergencyContactService _EmergencyContactService;

        public GetAllEmergencyContactsQueryHandler(IEmergencyContactService EmergencyContactService)
        {
            this._EmergencyContactService = EmergencyContactService;
        }

        public async Task<PagedResponse<List<EmergencyContactsDto>>> Handle(GetAllEmergencyContactsQuery request, CancellationToken cancellationToken)
        {
            return await _EmergencyContactService.GetAllEmergencyContacts(request, cancellationToken);
        }
    }
}

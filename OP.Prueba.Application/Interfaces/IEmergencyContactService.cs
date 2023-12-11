using OP.Prueba.Application.DTOs.EmergencyContacts;
using OP.Prueba.Application.Features.EmergencyContact.Queries.GetAllEmergencyContactsQuery;
using OP.Prueba.Application.Features.DeleteEmergencyContactCommand.Commands.DeleteEmergencyContactCommand;
using OP.Prueba.Application.Features.CreateEmergencyContactCommand.Commands.CreateEmergencyContactCommand;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Application.Features.UpdateEmergencyContactCommand.Commands.UpdateEmergencyContactCommand;
using OP.Prueba.Application.Features.GetEmergencyContactByIdQuery.Queries.GetEmergencyContactByIdQuery;

namespace OP.Prueba.Application.Interfaces
{
    public interface IEmergencyContactService
    {
        Task<PagedResponse<List<EmergencyContactsDto>>> GetAllEmergencyContacts(GetAllEmergencyContactsQuery request, CancellationToken cancellationToken);
        Task<Response<EmergencyContactsDto>> GetEmergencyContactById(GetEmergencyContactByIdQuery request, CancellationToken cancellationToken);
        Task<Response<int>> DeleteEmergencyContact(DeleteEmergencyContactCommand request, CancellationToken cancellationToken);
        Task<Response<int>> UpdateEmergencyContact(UpdateEmergencyContactCommand request, CancellationToken cancellationToken);
        Task<Response<int>> CreateEmergencyContact(CreateEmergencyContactCommand request, CancellationToken cancellationToken);
    }
}
using OP.Prueba.Application.DTOs.Persons;
using OP.Prueba.Application.Features.Person.Queries.GetAllPersonsQuery;
using OP.Prueba.Application.Features.DeletePersonCommand.Commands.DeletePersonCommand;
using OP.Prueba.Application.Features.CreatePersonCommand.Commands.CreatePersonCommand;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Application.Features.UpdatePersonCommand.Commands.UpdatePersonCommand;
using OP.Prueba.Application.Features.GetPersonByIdQuery.Queries.GetPersonByIdQuery;

namespace OP.Prueba.Application.Interfaces
{
    public interface IPersonService
    {
        Task<PagedResponse<List<PersonsDto>>> GetAllPersons(GetAllPersonsQuery request, CancellationToken cancellationToken);
        Task<Response<PersonsDto>> GetPersonById(GetPersonByIdQuery request, CancellationToken cancellationToken);
        Task<Response<int>> DeletePerson(DeletePersonCommand request, CancellationToken cancellationToken);
        Task<Response<int>> UpdatePerson(UpdatePersonCommand request, CancellationToken cancellationToken);
        Task<Response<int>> CreatePerson(CreatePersonCommand request, CancellationToken cancellationToken);
    }
}
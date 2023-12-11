using MediatR;
using OP.Prueba.Application.DTOs.Persons;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.Person.Queries.GetAllPersonsQuery
{
    public class GetAllPersonsQuery : IRequest<PagedResponse<List<PersonsDto>>>
    {
        public int? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Genero { get; set; }
        public int? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Email { get; set; }
        public long? TelefonoContacto { get; set; }
        public int? Usuario { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, PagedResponse<List<PersonsDto>>>
    {
        private readonly IPersonService _PersonService;

        public GetAllPersonsQueryHandler(IPersonService PersonService)
        {
            this._PersonService = PersonService;
        }

        public async Task<PagedResponse<List<PersonsDto>>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _PersonService.GetAllPersons(request, cancellationToken);
        }
    }
}

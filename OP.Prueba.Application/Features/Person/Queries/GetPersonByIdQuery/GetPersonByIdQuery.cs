using AutoMapper;
using MediatR;
using OP.Prueba.Application.DTOs.Persons;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.GetPersonByIdQuery.Queries.GetPersonByIdQuery
{
    public class GetPersonByIdQuery : IRequest<Response<PersonsDto>>
    {
        public int Id { get; set; }
        public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Response<PersonsDto>>
        {
            private readonly IPersonService _PersonService;

            public GetPersonByIdQueryHandler(IPersonService PersonService)
            {
                _PersonService = PersonService;
            }

            public async Task<Response<PersonsDto>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
            {
                return await _PersonService.GetPersonById(request, cancellationToken);
            }
        }
    }
}

using AutoMapper;
using MediatR;
using OP.Prueba.Application.DTOs.BookingPersons;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.GetBookingPersonByIdQuery.Queries.GetBookingPersonByIdQuery
{
    public class GetBookingPersonByIdQuery : IRequest<Response<BookingPersonsDto>>
    {
        public int Id { get; set; }
        public class GetBookingPersonByIdQueryHandler : IRequestHandler<GetBookingPersonByIdQuery, Response<BookingPersonsDto>>
        {
            private readonly IBookingPersonService _BookingPersonService;

            public GetBookingPersonByIdQueryHandler(IBookingPersonService BookingPersonService)
            {
                _BookingPersonService = BookingPersonService;
            }

            public async Task<Response<BookingPersonsDto>> Handle(GetBookingPersonByIdQuery request, CancellationToken cancellationToken)
            {
                return await _BookingPersonService.GetBookingPersonById(request, cancellationToken);
            }
        }
    }
}

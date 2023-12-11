using AutoMapper;
using MediatR;
using OP.Prueba.Application.DTOs.Bookings;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.GetBookingByIdQuery.Queries.GetBookingByIdQuery
{
    public class GetBookingByIdQuery : IRequest<Response<BookingsDto>>
    {
        public int Id { get; set; }
        public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, Response<BookingsDto>>
        {
            private readonly IBookingService _BookingService;

            public GetBookingByIdQueryHandler(IBookingService BookingService)
            {
                _BookingService = BookingService;
            }

            public async Task<Response<BookingsDto>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
            {
                return await _BookingService.GetBookingById(request, cancellationToken);
            }
        }
    }
}

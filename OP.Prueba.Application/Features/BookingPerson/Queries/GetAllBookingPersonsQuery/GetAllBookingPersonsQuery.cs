using MediatR;
using OP.Prueba.Application.DTOs.BookingPersons;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.BookingPerson.Queries.GetAllBookingPersonsQuery
{
    public class GetAllBookingPersonsQuery : IRequest<PagedResponse<List<BookingPersonsDto>>>
    {
        public int? Id { get; set; } = null;
        public int? Persona { get; set; } = null;
        public int? Reserva { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllBookingPersonsQueryHandler : IRequestHandler<GetAllBookingPersonsQuery, PagedResponse<List<BookingPersonsDto>>>
    {
        private readonly IBookingPersonService _BookingPersonService;

        public GetAllBookingPersonsQueryHandler(IBookingPersonService BookingPersonService)
        {
            this._BookingPersonService = BookingPersonService;
        }

        public async Task<PagedResponse<List<BookingPersonsDto>>> Handle(GetAllBookingPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _BookingPersonService.GetAllBookingPersons(request, cancellationToken);
        }
    }
}

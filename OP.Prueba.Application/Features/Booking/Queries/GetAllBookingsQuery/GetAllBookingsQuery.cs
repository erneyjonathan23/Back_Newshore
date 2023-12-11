using MediatR;
using OP.Prueba.Application.DTOs.Bookings;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.Booking.Queries.GetAllBookingsQuery
{
    public class GetAllBookingsQuery : IRequest<PagedResponse<List<BookingsDto>>>
    {
        public int? Id { get; set; }
        public int? Usuario { get; set; }
        public int? TipoViaje { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public int? Estado { get; set; } = null;
        public int? ContactoEmergencia { get; set; }
        public float? Precio { get; set; }
        public int? NumeroPersonas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, PagedResponse<List<BookingsDto>>>
    {
        private readonly IBookingService _BookingService;

        public GetAllBookingsQueryHandler(IBookingService BookingService)
        {
            this._BookingService = BookingService;
        }

        public async Task<PagedResponse<List<BookingsDto>>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            return await _BookingService.GetAllBookings(request, cancellationToken);
        }
    }
}

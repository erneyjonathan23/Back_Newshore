using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.UpdateBookingCommand.Commands.UpdateBookingCommand
{
    public class UpdateBookingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int TipoViaje { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int? Estado { get; set; } = null;
        public int? ContactoEmergencia { get; set; }
        public double? Precio { get; set; }
        public int? NumeroPersonas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Response<int>>
    {
        private readonly IBookingService _BookingService;

        public UpdateBookingCommandHandler(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        public async Task<Response<int>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            return await _BookingService.UpdateBooking(request, cancellationToken);
        }
    }
}

using AutoMapper;
using MediatR;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Services;
using OP.Prueba.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.CreateBookingCommand.Commands.CreateBookingCommand
{
    public class CreateBookingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int TipoViaje { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int? Estado { get; set; } = null;
        public int? ContactoEmergencia { get; set; }
        public float? Precio { get; set; }
        public int? NumeroPersonas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
    public class CreateDataMasterCommandHandler : IRequestHandler<CreateBookingCommand, Response<int>>
    {
        private readonly IBookingService _BookingService;

        public CreateDataMasterCommandHandler(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        public async Task<Response<int>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            return await _BookingService.CreateBooking(request, cancellationToken);
        }
    }
}
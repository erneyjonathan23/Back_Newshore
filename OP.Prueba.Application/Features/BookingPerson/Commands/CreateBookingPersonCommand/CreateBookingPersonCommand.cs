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

namespace OP.Prueba.Application.Features.CreateBookingPersonCommand.Commands.CreateBookingPersonCommand
{
    public class CreateBookingPersonCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; } = null;
        public int? Persona { get; set; } = null;
        public int? Reserva { get; set; } = null;
    }
    public class CreateDataMasterCommandHandler : IRequestHandler<CreateBookingPersonCommand, Response<int>>
    {
        private readonly IBookingPersonService _BookingPersonService;

        public CreateDataMasterCommandHandler(IBookingPersonService BookingPersonService)
        {
            _BookingPersonService = BookingPersonService;
        }

        public async Task<Response<int>> Handle(CreateBookingPersonCommand request, CancellationToken cancellationToken)
        {
            return await _BookingPersonService.CreateBookingPerson(request, cancellationToken);
        }
    }
}
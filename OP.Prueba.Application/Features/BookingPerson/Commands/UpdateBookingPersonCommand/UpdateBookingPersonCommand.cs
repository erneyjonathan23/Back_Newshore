using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.UpdateBookingPersonCommand.Commands.UpdateBookingPersonCommand
{
    public class UpdateBookingPersonCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; } = null;
        public int? Persona { get; set; } = null;
        public int? Reserva { get; set; } = null;
    }
    public class UpdateBookingPersonCommandHandler : IRequestHandler<UpdateBookingPersonCommand, Response<int>>
    {
        private readonly IBookingPersonService _BookingPersonService;

        public UpdateBookingPersonCommandHandler(IBookingPersonService BookingPersonService)
        {
            _BookingPersonService = BookingPersonService;
        }

        public async Task<Response<int>> Handle(UpdateBookingPersonCommand request, CancellationToken cancellationToken)
        {
            return await _BookingPersonService.UpdateBookingPerson(request, cancellationToken);
        }
    }
}

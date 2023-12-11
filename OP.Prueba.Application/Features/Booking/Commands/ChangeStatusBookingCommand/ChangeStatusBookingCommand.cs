using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.ChangeStatusBookingCommand.Commands.ChangeStatusBookingCommand
{
    public class ChangeStatusBookingCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; } = null;
    }
    public class ChangeStatusBookingCommandHandler : IRequestHandler<ChangeStatusBookingCommand, Response<int>>
    {
        private readonly IBookingService _BookingService;

        public ChangeStatusBookingCommandHandler(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        public async Task<Response<int>> Handle(ChangeStatusBookingCommand request, CancellationToken cancellationToken)
        {
            return await _BookingService.ChangeStatusBooking(request, cancellationToken);
        }
    }
}

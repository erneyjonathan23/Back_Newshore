using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.DeleteBookingCommand.Commands.DeleteBookingCommand
{
    public class DeleteBookingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, Response<int>>
    {
        private readonly IBookingService _BookingService;

        public DeleteBookingCommandHandler(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        public async Task<Response<int>> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            return await _BookingService.DeleteBooking(request, cancellationToken);
        }
    }
}

using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.DeleteBookingPersonCommand.Commands.DeleteBookingPersonCommand
{
    public class DeleteBookingPersonCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteBookingPersonCommandHandler : IRequestHandler<DeleteBookingPersonCommand, Response<int>>
    {
        private readonly IBookingPersonService _BookingPersonService;

        public DeleteBookingPersonCommandHandler(IBookingPersonService BookingPersonService)
        {
            _BookingPersonService = BookingPersonService;
        }

        public async Task<Response<int>> Handle(DeleteBookingPersonCommand request, CancellationToken cancellationToken)
        {
            return await _BookingPersonService.DeleteBookingPerson(request, cancellationToken);
        }
    }
}

using OP.Prueba.Application.DTOs.Bookings;
using OP.Prueba.Application.Features.Booking.Queries.GetAllBookingsQuery;
using OP.Prueba.Application.Features.DeleteBookingCommand.Commands.DeleteBookingCommand;
using OP.Prueba.Application.Features.CreateBookingCommand.Commands.CreateBookingCommand;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Application.Features.UpdateBookingCommand.Commands.UpdateBookingCommand;
using OP.Prueba.Application.Features.GetBookingByIdQuery.Queries.GetBookingByIdQuery;
using OP.Prueba.Application.Features.ChangeStatusBookingCommand.Commands.ChangeStatusBookingCommand;

namespace OP.Prueba.Application.Interfaces
{
    public interface IBookingService
    {
        Task<PagedResponse<List<BookingsDto>>> GetAllBookings(GetAllBookingsQuery request, CancellationToken cancellationToken);
        Task<Response<BookingsDto>> GetBookingById(GetBookingByIdQuery request, CancellationToken cancellationToken);
        Task<Response<int>> DeleteBooking(DeleteBookingCommand request, CancellationToken cancellationToken);
        Task<Response<int>> UpdateBooking(UpdateBookingCommand request, CancellationToken cancellationToken);
        Task<Response<int>> CreateBooking(CreateBookingCommand request, CancellationToken cancellationToken);
        Task<Response<int>> ChangeStatusBooking(ChangeStatusBookingCommand request, CancellationToken cancellationToken);
    }
}
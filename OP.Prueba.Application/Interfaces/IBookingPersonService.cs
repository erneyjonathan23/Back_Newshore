using OP.Prueba.Application.DTOs.BookingPersons;
using OP.Prueba.Application.Features.BookingPerson.Queries.GetAllBookingPersonsQuery;
using OP.Prueba.Application.Features.DeleteBookingPersonCommand.Commands.DeleteBookingPersonCommand;
using OP.Prueba.Application.Features.CreateBookingPersonCommand.Commands.CreateBookingPersonCommand;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Application.Features.UpdateBookingPersonCommand.Commands.UpdateBookingPersonCommand;
using OP.Prueba.Application.Features.GetBookingPersonByIdQuery.Queries.GetBookingPersonByIdQuery;

namespace OP.Prueba.Application.Interfaces
{
    public interface IBookingPersonService
    {
        Task<PagedResponse<List<BookingPersonsDto>>> GetAllBookingPersons(GetAllBookingPersonsQuery request, CancellationToken cancellationToken);
        Task<Response<BookingPersonsDto>> GetBookingPersonById(GetBookingPersonByIdQuery request, CancellationToken cancellationToken);
        Task<Response<int>> DeleteBookingPerson(DeleteBookingPersonCommand request, CancellationToken cancellationToken);
        Task<Response<int>> UpdateBookingPerson(UpdateBookingPersonCommand request, CancellationToken cancellationToken);
        Task<Response<int>> CreateBookingPerson(CreateBookingPersonCommand request, CancellationToken cancellationToken);
    }
}
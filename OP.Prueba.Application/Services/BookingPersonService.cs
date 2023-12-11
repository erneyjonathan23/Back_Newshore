using AutoMapper;
using OP.Prueba.Application.DTOs.BookingPersons;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Features.BookingPerson.Queries.GetAllBookingPersonsQuery;
using OP.Prueba.Application.Features.DeleteBookingPersonCommand.Commands.DeleteBookingPersonCommand;
using OP.Prueba.Application.Features.CreateBookingPersonCommand.Commands.CreateBookingPersonCommand;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Specifications;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;
using OP.Prueba.Application.Features.UpdateBookingPersonCommand.Commands.UpdateBookingPersonCommand;
using OP.Prueba.Application.Features.GetBookingPersonByIdQuery.Queries.GetBookingPersonByIdQuery;
using NPOI.POIFS.Crypt.Dsig;

namespace OP.Prueba.Application.Services
{
    public class BookingPersonService : IBookingPersonService
    {
        private readonly IRepositoryAsync<Domain.Entities.ReservaPersonas> _repositoryAsync;
        private readonly IRepositoryAsync<Domain.Entities.Personas> _repositoryPersonAsync;
        private readonly IRepositoryAsync<Domain.Entities.Reservas> _repositoryBookingAsync;
        private readonly IMapper _mapper;

        public BookingPersonService(IRepositoryAsync<ReservaPersonas> repositoryAsync, IRepositoryAsync<Personas> repositoryPersonAsync, IRepositoryAsync<Reservas> repositoryBookingAsync)
        {
            _repositoryAsync = repositoryAsync;
            _repositoryPersonAsync = repositoryPersonAsync;
            _repositoryBookingAsync = repositoryBookingAsync;
        }

        public async Task<PagedResponse<List<BookingPersonsDto>>> GetAllBookingPersons(GetAllBookingPersonsQuery request, CancellationToken cancellationToken)
        {
            var BookingPersons = await _repositoryAsync.ListAsync(new PagedBookingPersonSpecification(request.PageSize, request.PageNumber, request.Id, request.Persona, request.Reserva));
            var BookingPersonsCount = await _repositoryAsync.CountAsync(new PagedBookingPersonSpecification(null, null, request.Id, request.Persona, request.Reserva));
            var BookingPersonsDto = new List<BookingPersonsDto>();
            if (BookingPersons.Count > 0)
            {
                BookingPersonsDto = (from data in BookingPersons
                               select new BookingPersonsDto
                               {
                                   Id = data.Id,
                                   Reserva = data.Reserva,
                                   Persona = data.Persona,
                                   ReservaNavigation = _repositoryBookingAsync.GetByIdAsync(data.Reserva).Result,
                                   PersonaNavigation = _repositoryPersonAsync.GetByIdAsync(data.Persona).Result
                               }).ToList();
            }
            return new PagedResponse<List<BookingPersonsDto>>(BookingPersonsDto, request.PageNumber, request.PageSize, BookingPersonsCount);
        }

        public async Task<Response<int>> CreateBookingPerson(CreateBookingPersonCommand request, CancellationToken cancellationToken)
        {
            var newRegister = new ReservaPersonas()
            {
                Id = 0,
                Persona = (int)request.Persona,
                Reserva = (int)request.Reserva
            };
            var data = await _repositoryAsync.AddAsync(newRegister);
            var response = new Response<int>()
            {
                Message = "El registro se ha realizado exitosamente!",
                Data = data.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<BookingPersonsDto>> GetBookingPersonById(GetBookingPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var maestra = await _repositoryAsync.GetByIdAsync(request.Id);
            var dto = new BookingPersonsDto();

            if (maestra != null)
            {
                dto = new BookingPersonsDto
                {
                    Id = maestra.Id,
                    Persona = maestra.Persona,
                    Reserva = maestra.Reserva,
                    ReservaNavigation = _repositoryBookingAsync.GetByIdAsync(maestra.Reserva).Result,
                    PersonaNavigation = _repositoryPersonAsync.GetByIdAsync(maestra.Persona).Result
                };
            }
            var response = new Response<BookingPersonsDto>()
            {
                Message = "El registro se ha encontrado exitosamente!",
                Data = dto,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> DeleteBookingPerson(DeleteBookingPersonCommand request, CancellationToken cancellationToken)
        {
            var BookingPersono = await _repositoryAsync.GetByIdAsync(request.Id);
            if (BookingPersono == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            await _repositoryAsync.DeleteAsync(BookingPersono);
            var response = new Response<int>()
            {
                Message = "El registro se ha eliminado exitosamente!",
                Data = BookingPersono.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> UpdateBookingPerson(UpdateBookingPersonCommand request, CancellationToken cancellationToken)
        {
            var BookingPersono = await _repositoryAsync.GetByIdAsync(request.Id);
            if (BookingPersono == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            BookingPersono.Persona = (int)request.Persona;
            BookingPersono.Reserva = (int)request.Reserva;
            await _repositoryAsync.UpdateAsync(BookingPersono);
            var response = new Response<int>()
            {
                Message = "El registro se ha actualizado exitosamente!",
                Data = BookingPersono.Id,
                Succeeded = true
            };
            return response;
        }
    }
}
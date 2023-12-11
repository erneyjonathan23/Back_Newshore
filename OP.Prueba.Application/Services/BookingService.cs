using AutoMapper;
using OP.Prueba.Application.DTOs.Bookings;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Features.Booking.Queries.GetAllBookingsQuery;
using OP.Prueba.Application.Features.DeleteBookingCommand.Commands.DeleteBookingCommand;
using OP.Prueba.Application.Features.CreateBookingCommand.Commands.CreateBookingCommand;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Specifications;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;
using OP.Prueba.Application.Features.UpdateBookingCommand.Commands.UpdateBookingCommand;
using OP.Prueba.Application.Features.GetBookingByIdQuery.Queries.GetBookingByIdQuery;
using NPOI.POIFS.Crypt.Dsig;
using OP.Prueba.Application.Features.ChangeStatusBookingCommand.Commands.ChangeStatusBookingCommand;

namespace OP.Prueba.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepositoryAsync<Domain.Entities.Reservas> _repositoryAsync;
        private readonly IRepositoryAsync<Domain.Entities.ContactoEmergencia> _repositoryContactoAsync;
        private readonly IRepositoryAsync<Domain.Entities.Usuarios> _repositoryUsuarioAsync;
        private readonly IMapper _mapper;

        public BookingService(IRepositoryAsync<Reservas> repositoryAsync, IRepositoryAsync<ContactoEmergencia> repositoryContactoAsync, 
            IRepositoryAsync<Usuarios> repositoryUsuarioAsync)
        {
            _repositoryAsync = repositoryAsync;
            _repositoryContactoAsync = repositoryContactoAsync;
            _repositoryUsuarioAsync = repositoryUsuarioAsync;
        }

        public async Task<PagedResponse<List<BookingsDto>>> GetAllBookings(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var Bookings = await _repositoryAsync.ListAsync(new PagedBookingSpecification(request.PageSize, request.PageNumber, request.Id, request.Usuario,
                request.Estado, request.FechaInicio, request.FechaFin, request.TipoViaje, request.Origen, request.Destino));
            var BookingsCount = await _repositoryAsync.CountAsync(new PagedBookingSpecification(null, null, request.Id, request.Usuario,
                request.Estado, request.FechaInicio, request.FechaFin, request.TipoViaje, request.Origen, request.Destino));
            var BookingsDto = new List<BookingsDto>();
            if (Bookings.Count > 0)
            {
                BookingsDto = (from data in Bookings
                               select new BookingsDto
                               {
                                   Id = data.Id,
                                   Usuario = data.Usuario,
                                   Estado = data.Estado,
                                   FechaInicio = data.FechaInicio,
                                   FechaFin = data.FechaFin,
                                   FeBaja = data.FeBaja,
                                   FeRegistro = data.FeRegistro,
                                   TipoViaje = (int)data.TipoViaje,
                                   Origen = data.Origen,
                                   Destino = data.Destino,
                                   NumeroPersonas = (int)data.NumeroPersonas,
                                   Precio = (float)data.Precio,
                                   ContactoEmergencia = (int)data.ContactoEmergencia,
                                   ContactoEmergenciaNavigation = _repositoryContactoAsync.GetByIdAsync(Convert.ToInt32(data.ContactoEmergencia)).Result,
                                   UsuarioNavigation = _repositoryUsuarioAsync.GetByIdAsync(data.Usuario).Result,
                               }).ToList();
            }
            return new PagedResponse<List<BookingsDto>>(BookingsDto, request.PageNumber, request.PageSize, BookingsCount);
        }

        public async Task<Response<int>> CreateBooking(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var newRegister = new Reservas()
            {
                Id = 0,
                Usuario = (int)request.Usuario,
                Estado = (int)request.Estado,
                FechaInicio = (DateTime)request.FechaInicio,
                FechaFin = (DateTime)request.FechaFin,
                FeRegistro = DateTime.Now,
                TipoViaje = request.TipoViaje,
                Origen = request.Origen,
                Destino = request.Destino,
                ContactoEmergencia = request.ContactoEmergencia,
                NumeroPersonas = request.NumeroPersonas,
                Precio = request.Precio
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

        public async Task<Response<BookingsDto>> GetBookingById(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var maestra = await _repositoryAsync.GetByIdAsync(request.Id);
            var dto = new BookingsDto();

            if (maestra != null)
            {
                dto = new BookingsDto
                {
                    Id = maestra.Id,
                    Usuario = maestra.Usuario,
                    Estado = maestra.Estado,
                    FechaInicio = maestra.FechaInicio,
                    FechaFin = maestra.FechaFin,
                    FeBaja = maestra.FeBaja,
                    FeRegistro = maestra.FeRegistro,
                    TipoViaje = (int)maestra.TipoViaje,
                    Origen = maestra.Origen,
                    Destino = maestra.Destino,
                    ContactoEmergencia = (int)maestra.ContactoEmergencia,
                    NumeroPersonas = (int)maestra.NumeroPersonas,
                    Precio = (float)maestra.Precio,
                    ContactoEmergenciaNavigation = await _repositoryContactoAsync.GetByIdAsync(maestra.ContactoEmergencia),
                    UsuarioNavigation = await _repositoryUsuarioAsync.GetByIdAsync(maestra.Usuario),
                };
            }
            var response = new Response<BookingsDto>()
            {
                Message = "El registro se ha encontrado exitosamente!",
                Data = dto,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> DeleteBooking(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var Bookingo = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Bookingo == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            await _repositoryAsync.DeleteAsync(Bookingo);
            var response = new Response<int>()
            {
                Message = "El registro se ha eliminado exitosamente!",
                Data = Bookingo.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> UpdateBooking(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var Bookingo = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Bookingo == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            Bookingo.Estado = (int)request.Estado;
            Bookingo.FechaFin = (DateTime)request.FechaFin;
            await _repositoryAsync.UpdateAsync(Bookingo);
            var response = new Response<int>()
            {
                Message = "El registro se ha actualizado exitosamente!",
                Data = Bookingo.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> ChangeStatusBooking(ChangeStatusBookingCommand request, CancellationToken cancellationToken)
        {
            var Booking = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Booking == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            Booking.Estado = Booking.Estado == 0 ? 1 : 0;
            await _repositoryAsync.UpdateAsync(Booking);
            var response = new Response<int>()
            {
                Message = $"Se ha " + (Booking.Estado == 0 ? "Habilitado" : "Deshabilitado") + " el registro: " + Booking.Id,
                Data = Booking.Id,
                Succeeded = true
            };
            return response;
        }
    }
}
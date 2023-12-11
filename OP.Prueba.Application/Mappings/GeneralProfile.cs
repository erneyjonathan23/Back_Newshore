using AutoMapper;
using OP.Prueba.Application.DTOs.Bookings;
using OP.Prueba.Application.Features.CreateBookingCommand.Commands.CreateBookingCommand;
using OP.Prueba.Application.Features.CreatePersonCommand.Commands.CreatePersonCommand;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            #endregion

            #region Models
            CreateMap<BookingsDto, Reservas>();
            #endregion

            #region Commands
            CreateMap<CreatePersonCommand, Personas>();
            CreateMap<CreateBookingCommand, Reservas>();
            #endregion
        }
    }
}

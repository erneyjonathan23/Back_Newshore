using OP.Prueba.Application.Parameters;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs.BookingPersons
{
    public class BookingPersonsRequest : RequestParameter
    {
        public int? Id { get; set; } = null;
        public int? Persona { get; set; } = null;
        public int? Reserva { get; set; } = null;
    }
}

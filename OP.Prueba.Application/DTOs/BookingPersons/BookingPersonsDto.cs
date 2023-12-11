using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs.BookingPersons
{
    public class BookingPersonsDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public int Persona { get; set; }
        public int Reserva { get; set; }
        public virtual Personas PersonaNavigation { get; set; } = null!;
        public virtual Reservas ReservaNavigation { get; set; } = null!;
    }
}
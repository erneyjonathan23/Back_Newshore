using OP.Prueba.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Domain.Entities
{
    public class ReservaPersonas : AuditableBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Persona { get; set; }
        public int Reserva { get; set; }
        public virtual Personas PersonaNavigation { get; set; } = null!;
        public virtual Reservas ReservaNavigation { get; set; } = null!;
    }
} 
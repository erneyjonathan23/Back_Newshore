using OP.Prueba.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Domain.Entities
{
    public class ContactoEmergencia : AuditableBaseEntity
    {
        public ContactoEmergencia()
        {
            Reservas = new List<Reservas>();
        }
        [Key]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public long NumeroContacto { get; set; }
        public string? Email { get; set; } = null;
        public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
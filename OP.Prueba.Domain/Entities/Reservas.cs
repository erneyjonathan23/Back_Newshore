using OP.Prueba.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Domain.Entities
{
    public class Reservas : AuditableBaseEntity
    {
        public Reservas()
        {
            ReservaPersonas = new HashSet<ReservaPersonas>();
        }

        [Key]
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int TipoViaje { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int? Estado { get; set; } = null;
        public int? ContactoEmergencia { get; set; }
        public float? Precio { get; set; }
        public int? NumeroPersonas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public virtual Usuarios UsuarioNavigation { get; set; } = null!;
        public virtual ContactoEmergencia ContactoEmergenciaNavigation { get; set; } = null!;
        public virtual ICollection<ReservaPersonas> ReservaPersonas { get; set; }
    }
}
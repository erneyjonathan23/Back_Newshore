using OP.Prueba.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Domain.Entities
{
    public class Personas : AuditableBaseEntity
    {
        public Personas()
        {
            ReservaPersonas = new HashSet<ReservaPersonas>();
        }

        [Key]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Genero { get; set; }
        public int TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string? Email { get; set; }
        public long? TelefonoContacto { get; set; }
        public int? Usuario { get; set; }
        public virtual Generos GeneroNavigation { get; set; } = null!;
        public virtual TiposDocumento TipoDocumentoNavigation { get; set; } = null!;
        public virtual Usuarios? UsuarioNavigation { get; set; }
        public virtual ICollection<ReservaPersonas> ReservaPersonas { get; set; }
    }
} 
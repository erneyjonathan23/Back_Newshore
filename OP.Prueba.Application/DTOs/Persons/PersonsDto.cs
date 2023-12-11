using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs.Persons
{
    public class PersonsDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Genero { get; set; }
        public int TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string? Email { get; set; }
        public long? TelefonoContacto { get; set; }
        public int? Usuario { get; set; } = null;
        public virtual Generos GeneroNavigation { get; set; } = null!;
        public virtual TiposDocumento TipoDocumentoNavigation { get; set; } = null!;
        public virtual Usuarios UsuarioNavigation { get; set; } = null!;
    }
}

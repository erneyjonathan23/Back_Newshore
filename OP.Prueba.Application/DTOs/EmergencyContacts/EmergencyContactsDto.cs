using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.DTOs.EmergencyContacts
{
    public class EmergencyContactsDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public long NumeroContacto { get; set; }
        public string? Email { get; set; } = null;
        public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
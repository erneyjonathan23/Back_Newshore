using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.DTOs.DocumentTypes
{
    public class DocumentTypesDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string TipoDocumento { get; set; }
        public virtual ICollection<Personas> Personas { get; set; }
    }
}
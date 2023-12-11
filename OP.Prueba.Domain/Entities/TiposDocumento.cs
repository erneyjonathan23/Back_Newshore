using OP.Prueba.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Domain.Entities
{
    public class TiposDocumento : AuditableBaseEntity
    {
        public TiposDocumento()
        {
            Personas = new HashSet<Personas>();
        }

        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string TipoDocumento { get; set; }
        public virtual ICollection<Personas> Personas { get; set; }
    }
}
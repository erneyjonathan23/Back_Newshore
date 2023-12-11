using OP.Prueba.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Domain.Entities
{
    public class Roles : AuditableBaseEntity
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
        public int? Nivel { get; set; } = null;
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
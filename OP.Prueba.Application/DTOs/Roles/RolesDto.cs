using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs.Roles
{
    public class RolesDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public int? Nivel { get; set; } = null;
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}

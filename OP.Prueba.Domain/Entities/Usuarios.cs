using OP.Prueba.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Domain.Entities
{
    public class Usuarios : AuditableBaseEntity
    {
        public Usuarios()
        {
            Reservas = new HashSet<Reservas>();
            Personas = new HashSet<Personas>();
        }

        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int Role { get; set; }
        public virtual Roles RoleNavigation { get; set; } = null!;
        public virtual ICollection<Reservas> Reservas { get; set; }
        public virtual ICollection<Personas> Personas { get; set; } 
    }
}
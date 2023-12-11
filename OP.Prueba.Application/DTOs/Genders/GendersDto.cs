using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs.Genders
{
    public class GendersDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Genero { get; set; }
        public virtual ICollection<Personas> Personas { get; set; }
    }
}

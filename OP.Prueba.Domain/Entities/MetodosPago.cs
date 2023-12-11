using OP.Prueba.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Domain.Entities
{
    public class MetodosPago : AuditableBaseEntity
    {
        public MetodosPago()
        {
        }

        [Key]
        public int Id { get; set; }
        public string MetodoPago { get; set; }
    }
}
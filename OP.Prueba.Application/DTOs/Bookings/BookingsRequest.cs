using OP.Prueba.Application.Parameters;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs.Bookings
{
    public class BookingsRequest : RequestParameter
    {
        public int? Id { get; set; }
        public int? Usuario { get; set; }
        public int? TipoViaje { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public int? Estado { get; set; } = null;
        public int? ContactoEmergencia { get; set; }
        public float? Precio { get; set; }
        public int? NumeroPersonas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}

using OP.Prueba.Application.Parameters;
using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OP.Prueba.Application.DTOs.EmergencyContacts
{
    public class EmergencyContactsRequest : RequestParameter
    {
        public int? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public long? NumeroContacto { get; set; }
        public string? Email { get; set; } = null;
    }
}
using OP.Prueba.Domain.Entities;
using System.Text.Json.Serialization;

namespace OP.Prueba.Application.DTOs.Users
{
    public class RegisterRequest
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string ConfirmarContrasena { get; set; }
        public int Role { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Genero { get; set; }
        public int TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public long TelefonoContacto { get; set; }
    }
}
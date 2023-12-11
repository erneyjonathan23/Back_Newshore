using OP.Prueba.Domain.Entities;
using System.Text.Json.Serialization;

namespace OP.Prueba.Application.DTOs.Users
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; } = null;
        public int Role { get; set; }
        public string RoleName { get; set; }
        public int Nivel { get; set; }
        public bool IsVerified { get; set; }
        public string JWToken { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
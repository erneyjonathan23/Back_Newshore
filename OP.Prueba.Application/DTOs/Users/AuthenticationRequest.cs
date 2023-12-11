using System.Text.Json.Serialization;

namespace OP.Prueba.Application.DTOs.Users
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
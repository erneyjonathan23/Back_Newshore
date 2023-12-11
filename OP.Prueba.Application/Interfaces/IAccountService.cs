using OP.Prueba.Application.DTOs.Users;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
    }
}
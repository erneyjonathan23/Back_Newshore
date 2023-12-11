using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.DTOs.Users;
using OP.Prueba.Application.Features.Authenticate.Commands.AuthenticateCommand;
using OP.Prueba.Application.Features.Authenticate.Commands.RegisterCommand;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AccountController : BaseApiController
    {
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await Mediator.Send(new AuthenticateCommand
            {
                UserName = request.UserName,
                Password = request.Password,
                IpAddress = GenerateIpAddress()
            }));
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await Mediator.Send(new RegisterCommand
            {
                Usuario = request.Usuario,
                Contrasena = request.Contrasena,
                ConfirmarContrasena = request.ConfirmarContrasena,
                Role = request.Role,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                FechaNacimiento = request.FechaNacimiento,
                Genero = request.Genero,
                TipoDocumento = request.TipoDocumento,
                NumeroDocumento = request.NumeroDocumento,
                Email = request.Email,
                TelefonoContacto = request.TelefonoContacto,
                Origin = Request.Headers["origin"]
            }));
        }
        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}

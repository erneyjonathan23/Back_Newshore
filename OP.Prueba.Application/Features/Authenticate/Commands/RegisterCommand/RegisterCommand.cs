using MediatR;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommand : IRequest<Response<string>>
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
        public string Origin { get; set; }
    }
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<string>>
    {
        private readonly IAccountService _accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.RegisterAsync(new DTOs.Users.RegisterRequest
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
                TelefonoContacto = request.TelefonoContacto
            }, request.Origin);
        }
    }
}

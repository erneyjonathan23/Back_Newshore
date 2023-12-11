using Microsoft.IdentityModel.Tokens;
using Moq;
using OP.Prueba.Application.DTOs.Users;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Specifications;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;
using OP.Prueba.Domain.Settings;
using OP.Prueba.Identity.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OP.Prueba.Test.Mocks
{
    public class MockAccountService : IAccountService
    {
        private readonly Mock<IRepositoryAsync<Domain.Entities.Usuarios>> _mockRepositoryUsuariosAsync;
        private readonly Mock<IRepositoryAsync<Domain.Entities.Personas>> _mockRepositoryPersonasAsync;
        private readonly Mock<IRepositoryAsync<Domain.Entities.Roles>> _mockRepositoryRolesAsync;
        List<Usuarios> _mockUsuarios = new List<Usuarios>()
        {
            new Usuarios
            {
                Id = 1,
                Usuario = "Admin",
                Contrasena = "De1234567",
                Role = (int)Application.Enums.Roles.Admin
            }
        };
        List<Roles> _mockRoles = new List<Roles>()
            {
                new Roles
                {
                    Id = 1,
                    Role = "Admin",
                    Nivel = (int)Application.Enums.Roles.Admin,
                },
                new Roles {
                    Id = 2,
                    Role = "Cliente",
                    Nivel = (int)Application.Enums.Roles.Cliente,
                }
            };
        List<Personas> _mockPersonas = new List<Personas>()
        {
            new Personas
            {
                Id = 1,
                Nombres = "Admin",
                Apellidos = "Admin",
                FechaNacimiento = new DateTime(1999, 4, 15),
                Genero = (int)Application.Enums.Generos.Masculino,
                TipoDocumento = (int)Application.Enums.TiposDocumentos.CedulaCiudadania,
                NumeroDocumento = "1017270383",
                Email = "Admin@smartalentit.com",
                TelefonoContacto = 3113643147,
                Usuario = 1,
            }
        };
        public string Key { get; set; } = "Ca455Smartasdasas7454Talentmi48484dssdMi454sadaslo84548";
        public string Issuer { get; set; } = "PruebaIssuer";
        public string Audience { get; set; } = "PruebaAudience";
        public double DurationMinutes { get; set; } = 400;

        public MockAccountService(Mock<IRepositoryAsync<Usuarios>> mockRepositoryUsuariosAsync, Mock<IRepositoryAsync<Personas>> mockRepositoryPersonasAsync, Mock<IRepositoryAsync<Roles>> mockRepositoryRolesAsync)
        {
            _mockRepositoryUsuariosAsync = mockRepositoryUsuariosAsync;
            _mockRepositoryPersonasAsync = mockRepositoryPersonasAsync;
            _mockRepositoryRolesAsync = mockRepositoryRolesAsync;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var alreadyRegisteredUser = _mockUsuarios.FirstOrDefault(x => x.Usuario == request.UserName);
            if (alreadyRegisteredUser == null)
                throw new ApiException($"No hay una cuenta registrada con el usuario: {request.UserName}.");

            if (alreadyRegisteredUser.Usuario != request.UserName || alreadyRegisteredUser.Contrasena != request.Password)
                throw new ApiException($"El usuario y contraseña ingresado no coinciden con los registrados, intentelo otra vez.");

            var userDto = new UsersDto()
            {
                Id = alreadyRegisteredUser.Id,
                Contrasena = alreadyRegisteredUser.Contrasena,
                Usuario = alreadyRegisteredUser.Usuario,
                Role = alreadyRegisteredUser.Role,
                RoleNavigation = _mockRoles.FirstOrDefault(x => x.Id == alreadyRegisteredUser.Role),
                PersonaNavigation = _mockPersonas.FirstOrDefault(x => x.Usuario == alreadyRegisteredUser.Id)
            };

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(userDto);
            var response = new AuthenticationResponse()
            {
                Id = userDto.Id,
                JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = userDto.PersonaNavigation.Email,
                UserName = userDto.Usuario,
                Role = userDto.Role,
                Nivel = (int)userDto.RoleNavigation.Nivel,
                IsVerified = true,
                Nombres = userDto.PersonaNavigation.Nombres,
                Apellidos = userDto.PersonaNavigation.Apellidos,
                RoleName = userDto.RoleNavigation.Role,
            };
            var refreshToken = GenerateRefreshToken(ipAddress);
            response.RefreshToken = refreshToken.Token;
            return new Response<AuthenticationResponse>(response, $"Usuario autenticado: {userDto.Usuario}");
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            CancellationToken cancellationToken = new CancellationToken();
            var alreadyRegisteredUser = _mockUsuarios.FirstOrDefault(x => x.Usuario == request.Usuario);
            if (alreadyRegisteredUser != null)
                throw new ApiException($"El nombre de usuario {request.Usuario} ya fue registrado previamente.");

            if (request.Contrasena != request.ConfirmarContrasena)
                throw new ApiException($"La contraseña debe ser igual en los dos campos.");

            var user = new Usuarios() { Id = 0, Usuario = request.Usuario, Contrasena = request.Contrasena, Role = request.Role };
            _mockRepositoryUsuariosAsync.Setup(a => a.AddAsync(user, cancellationToken)).Returns(Task.FromResult(user));
            var userAdd = await _mockRepositoryUsuariosAsync.Object.AddAsync(user);
            var person = new Personas()
            {
                Id = 0,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                FechaNacimiento = request.FechaNacimiento,
                Genero = request.Genero,
                TipoDocumento = request.TipoDocumento,
                NumeroDocumento = request.NumeroDocumento,
                Usuario = userAdd.Id,
                Email = request.Email,
                TelefonoContacto = request.TelefonoContacto
            };
            _mockRepositoryPersonasAsync.Setup(a => a.AddAsync(person, cancellationToken)).Returns(Task.FromResult(person));
            var personAdd = await _mockRepositoryPersonasAsync.Object.AddAsync(person);

            var response = new Response<string>()
            {
                Message = "El registro se ha realizado exitosamente!",
                Data = user.Usuario,
                Succeeded = true
            };
            return response;
        }

        private async Task<JwtSecurityToken> GenerateJWToken(UsersDto user)
        {
            var ipAddress = IpHelper.GetIpAddress();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Usuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.PersonaNavigation.Email),
                new Claim("roles", user.Role.ToString()),
                new Claim("ip", ipAddress),
                new Claim("id", user.Id.ToString())
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jswSecurityToken = new JwtSecurityToken(
                issuer: this.Issuer,
                audience: this.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(this.DurationMinutes),
                signingCredentials: signingCredentials
                );

            return jswSecurityToken;
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now,
                CreatedByIp = ipAddress,
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}

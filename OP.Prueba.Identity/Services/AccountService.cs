using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
using System.Threading.Tasks;

namespace OP.Prueba.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IRepositoryAsync<Domain.Entities.Usuarios> _repositoryUsuariosAsync;
        private readonly IRepositoryAsync<Domain.Entities.Personas> _repositoryPersonasAsync;
        private readonly IRepositoryAsync<Domain.Entities.Roles> _repositoryRolesAsync;
        private readonly IMapper _mapper;

        public AccountService(IRepositoryAsync<Usuarios> repositoryUsuariosAsync, IDateTimeService dateTimeService, IOptions<JWTSettings> jwtSettings,
            IRepositoryAsync<Personas> repositoryPersonasAsync, IMapper mapper, IRepositoryAsync<Roles> repositoryRolesAsync)
        {
            _repositoryUsuariosAsync = repositoryUsuariosAsync;
            _jwtSettings = jwtSettings.Value;
            _repositoryPersonasAsync = repositoryPersonasAsync;
            _repositoryRolesAsync = repositoryRolesAsync;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var alreadyRegisteredUser = await _repositoryUsuariosAsync.GetBySpecAsync(new PagedUserSpecification(null, null, null, request.UserName));
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
                RoleNavigation = await _repositoryRolesAsync.GetByIdAsync(alreadyRegisteredUser.Role),
                PersonaNavigation = await _repositoryPersonasAsync.GetBySpecAsync(new PagedPersonSpecification(null, null, null, alreadyRegisteredUser.Id, null, null, null, null, null, null, null))
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
            var alreadyRegisteredUser = await _repositoryUsuariosAsync.GetBySpecAsync(new PagedUserSpecification(null, null, null, request.Usuario));
            if (alreadyRegisteredUser != null)
                throw new ApiException($"El nombre de usuario {request.Usuario} ya fue registrado previamente.");

            if (request.Contrasena != request.ConfirmarContrasena)
                throw new ApiException($"La contraseña debe ser igual en los dos campos.");

            var user = new Usuarios() { Id = 0, Usuario = request.Usuario, Contrasena = request.Contrasena, Role = request.Role };
            var userAdd = await _repositoryUsuariosAsync.AddAsync(user);
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
            var personAdd = await _repositoryPersonasAsync.AddAsync(person);

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

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jswSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationMinutes),
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
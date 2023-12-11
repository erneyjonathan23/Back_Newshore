using Moq;
using OP.Prueba.Application.Features.Authenticate.Commands.RegisterCommand;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Domain.Settings;
using OP.Prueba.Test.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static NPOI.HSSF.UserModel.HeaderFooter;

namespace OP.Prueba.Test.Features.Bill.Commands.RegisterCommandTest
{
    public class RegisterCommandTest
    {
        private readonly Mock<IRepositoryAsync<Domain.Entities.Usuarios>> _mockRepositoryUsuariosAsync;
        private readonly Mock<IRepositoryAsync<Domain.Entities.Personas>> _mockRepositoryPersonasAsync;
        private readonly Mock<IRepositoryAsync<Domain.Entities.Roles>> _mockRepositoryRolesAsync;
        private readonly RegisterCommandHandler _handler;
        private readonly IAccountService _accountService;

        public RegisterCommandTest()
        {
            _mockRepositoryUsuariosAsync = new Mock<IRepositoryAsync<Domain.Entities.Usuarios>>();
            _mockRepositoryPersonasAsync = new Mock<IRepositoryAsync<Domain.Entities.Personas>>();
            _mockRepositoryRolesAsync = new Mock<IRepositoryAsync<Domain.Entities.Roles>>();
            _accountService = new MockAccountService(_mockRepositoryUsuariosAsync, _mockRepositoryPersonasAsync, _mockRepositoryRolesAsync);
            _handler = new RegisterCommandHandler(_accountService);
        }

        [Fact]
        public async Task RegisterCommandTest_SucceededTrue()
        {
            //Arrange
            CancellationToken cancellationToken = new CancellationToken();
            var register = new RegisterCommand {
                Usuario = "erneypuerta",
                Contrasena = "987456",
                ConfirmarContrasena = "987456",
                Role = 2,
                Nombres = "Jonathan Erney",
                Apellidos = "Puerta",
                FechaNacimiento = DateTime.Parse("1999-04-15"),
                Genero = 1,
                TipoDocumento = 1,
                NumeroDocumento = "54545212",
                Email = "erneyjonathan@gmail.com",
                TelefonoContacto = 5445454,
                Origin = ""
            };

            //Act
            var response = await _handler.Handle(register, cancellationToken);

            //Assert
            Assert.True(response.Succeeded == true);
        }
    }
}

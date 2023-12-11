using Moq;
using OP.Prueba.Application.Features.Authenticate.Commands.AuthenticateCommand;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Domain.Settings;
using OP.Prueba.Test.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static NPOI.HSSF.UserModel.HeaderFooter;

namespace OP.Prueba.Test.Features.Bill.Commands.AuthenticateCommandTest
{
    public class AuthenticateCommandTest
    {
        private readonly Mock<IRepositoryAsync<Domain.Entities.Usuarios>> _mockRepositoryUsuariosAsync;
        private readonly Mock<IRepositoryAsync<Domain.Entities.Personas>> _mockRepositoryPersonasAsync;
        private readonly Mock<IRepositoryAsync<Domain.Entities.Roles>> _mockRepositoryRolesAsync;
        private readonly AuthenticateCommandHandler _handler;
        private readonly IAccountService _accountService;

        public AuthenticateCommandTest()
        {
            _mockRepositoryUsuariosAsync = new Mock<IRepositoryAsync<Domain.Entities.Usuarios>>();
            _mockRepositoryPersonasAsync = new Mock<IRepositoryAsync<Domain.Entities.Personas>>();
            _mockRepositoryRolesAsync = new Mock<IRepositoryAsync<Domain.Entities.Roles>>();
            _accountService = new MockAccountService(_mockRepositoryUsuariosAsync, _mockRepositoryPersonasAsync, _mockRepositoryRolesAsync);
            _handler = new AuthenticateCommandHandler(_accountService);
        }

        [Fact]
        public async Task AuthenticateCommandTest_SucceededTrue()
        {
            //Arrange
            CancellationToken cancellationToken = new CancellationToken();
            var register = new AuthenticateCommand { UserName = "Admin", Password="De1234567" };

            //Act
            var response = await _handler.Handle(register, cancellationToken);

            //Assert
            Assert.True(response.Succeeded == true);
        }
    }
}

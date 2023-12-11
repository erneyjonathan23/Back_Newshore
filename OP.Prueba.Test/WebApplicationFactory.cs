using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Test.Mocks;

namespace OP.Prueba.Test
{
    public class ApiWebApplicationFactory : WebApplicationFactory<WebAPI.Program>
    {
        public IConfiguration Configuration { get; private set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.UnitTest.json", false, false)
                .Build();
                config.AddConfiguration(Configuration);
            }).UseEnvironment("UnitTest").ConfigureTestServices(services =>
            {
                services.Replace(ServiceDescriptor.Scoped<IAccountService, MockAccountService>());
            });
        }
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("UnitTest").ConfigureServices(services =>
            {
                services.Replace(ServiceDescriptor.Singleton<IAccountService, MockAccountService>());
            });
            return base.CreateHost(builder);
        }
    }
}

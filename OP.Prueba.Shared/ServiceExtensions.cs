using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Shared.Services;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Shared.Services;

namespace OP.Prueba.Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IGenericClientHttpService, GenericClientHttpService>();
            services.AddTransient<ICurrencyConvertService, CurrencyConvertService>();
            services.AddTransient<IGetTravelRouteService, GetTravelRouteService>();
            services.AddTransient<ITravelRouteService, TravelRouteService>();
        }
    }
}

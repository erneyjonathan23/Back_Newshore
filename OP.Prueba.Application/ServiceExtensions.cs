using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OP.Prueba.Application.Behaviours;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Services;
using System.Reflection;

namespace OP.Prueba.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            #region Services
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IDocumentTypeService, DocumentTypeService>();
            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IEmergencyContactService, EmergencyContactService>();
            services.AddTransient<IBookingPersonService, BookingPersonService>();
            #endregion
        }
    }
}
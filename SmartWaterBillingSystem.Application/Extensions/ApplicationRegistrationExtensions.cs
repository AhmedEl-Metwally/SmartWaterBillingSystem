using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartWaterBillingSystem.Application.Behaviors;
using System.Reflection;

namespace SmartWaterBillingSystem.Application.Extensions
{
    public static class ApplicationRegistrationExtensions
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection Service)
        {
            Service.AddMediatR(cfg => 
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            });

            Service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return Service;
        }
    }
}

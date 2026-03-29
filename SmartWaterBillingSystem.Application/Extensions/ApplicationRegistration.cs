using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SmartWaterBillingSystem.Application.Extensions
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection Service)
        {
            Service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return Service;
        }
    }
}

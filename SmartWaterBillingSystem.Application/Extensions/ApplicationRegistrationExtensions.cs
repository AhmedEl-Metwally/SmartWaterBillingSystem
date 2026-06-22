namespace SmartWaterBillingSystem.Application.Extensions
{
    public static class ApplicationRegistrationExtensions
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection Service)
        {
            Service.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            Service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return Service;
        }
    }
}

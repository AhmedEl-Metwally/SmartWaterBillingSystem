namespace SmartWaterBillingSystem.Client.Client.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services, string apiBaseUrl)
        {
            services.AddMudServices();
            services.AddBlazoredLocalStorage();
            services.AddScoped(S => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

            return services;
        }
    }
}
